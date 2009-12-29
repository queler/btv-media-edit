/****************************************************************************
 * 
 * File:  MediaFile.cs
 * 
 * Copyright (C) 2009  Brett Gronholz
 * 
 * This file is part of BTV Media Edit.
 * 
 * BTV Media Edit is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * BTV Media Edit is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with BTV Media Edit.  If not, see <http://www.gnu.org/licenses/>.
 ***************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BTVMediaEdit
{
    using BTVServer;
    using TvdbLib;
    using TvdbLib.Cache;
    using TvdbLib.Data;

    public class MediaFile
    {
        public string FullName = String.Empty;
        public string Title = String.Empty;
        public int Season = -1;
        public int Episode = -1;
        public string EpisodeTitle = "Unknown";
        public string EpisodeDescription = "Unknown";
        public DateTime OriginalAirDate = new DateTime();
        public string Actors = String.Empty;

        //###################################################################

        public MediaFile(string path)
        {
            FullName = path;
            ParseFileName(Path.GetFileName(path));
        }

        public bool IsValid()
        {
            return ( !Title.Equals(String.Empty) && 
                (((Season >= 0) && (Episode >= 0)) || (OriginalAirDate.Ticks > 0)) );
        }

        public bool RetrieveInfo(string seriesName, int seriesID)
        {
            try
            {
                if (!IsValid())
                {
                    return false;
                }

                Title = seriesName;

                TvdbHandler t;
                string cachePath = TvDb.GetCachePath();
                if (cachePath.Equals(String.Empty))
                {
                    t = new TvdbHandler(TvDb.TVDB_API_KEY);
                }
                else
                {
                    t = new TvdbHandler(new XmlCacheProvider(cachePath), TvDb.TVDB_API_KEY);
                }
                t.InitCache();

                TvdbSeries s = t.GetBasicSeries(seriesID, TvdbLanguage.DefaultLanguage, false);

                TvdbEpisode e;
                if (Season.Equals(-1))
                {
                    e = t.GetEpisode(seriesID, OriginalAirDate, TvdbLanguage.DefaultLanguage);
                    Season = e.SeasonNumber;
                    Episode = e.EpisodeNumber;
                }
                else
                {
                    e = t.GetEpisode(seriesID, Season, Episode, TvdbEpisode.EpisodeOrdering.DefaultOrder, TvdbLanguage.DefaultLanguage);
                }

                EpisodeTitle = e.EpisodeName;
                EpisodeDescription = e.Overview.TrimEnd(new char[] {'\n'});
                OriginalAirDate = e.FirstAired;
                foreach (string act in s.Actors)
                {
                    Actors += String.Format("{0}, ", act);
                }
                Actors = Actors.TrimEnd(new char[] { ',', ' ' });
            }
            catch
            {
                return false;
            }

            return true;
        }

        public PVSPropertyBag ToPVSPropertyBag()
        {
            PVSProperty pTitle = new PVSProperty();
            pTitle.Name = "Title";
            pTitle.Value = Title;

            PVSProperty pEpisodeTitle = new PVSProperty();
            pEpisodeTitle.Name = "EpisodeTitle";
            pEpisodeTitle.Value = EpisodeTitle;

            PVSProperty pEpisodeDescription = new PVSProperty();
            pEpisodeDescription.Name = "EpisodeDescription";
            if ((Season > 0) && (Episode > 0))
            {
                pEpisodeDescription.Value = String.Format("S{0:00}E{1:00} - {2}", Season, Episode, EpisodeDescription);
            }
            else
            {
                pEpisodeDescription.Value = EpisodeDescription;
            }

            PVSProperty pActors = new PVSProperty();
            pActors.Name = "Actors";
            pActors.Value = Actors;

            PVSProperty pOriginalAirDate = new PVSProperty();
            pOriginalAirDate.Name = "OriginalAirDate";
            pOriginalAirDate.Value = OriginalAirDate.ToString("yyyyMMdd");

            PVSProperty pActualStart = new PVSProperty();
            pActualStart.Name = "ActualStart";
            if (OriginalAirDate.Ticks.Equals(0))
            {
                pActualStart.Value = DateTime.Now.ToFileTime().ToString();
            }
            else
            {
                pActualStart.Value = (OriginalAirDate.ToFileTime() + 144000000000).ToString();
            }

            List<PVSProperty> propList = new List<PVSProperty>();
            propList.Add(pTitle);
            propList.Add(pEpisodeTitle);
            propList.Add(pEpisodeDescription);
            propList.Add(pActors);
            propList.Add(pOriginalAirDate);
            propList.Add(pActualStart);

            PVSPropertyBag bag = new PVSPropertyBag();
            bag.Properties = (PVSProperty[])propList.ToArray<PVSProperty>();
            return bag;
        }

        //###################################################################

        private void ParseFileName(string fileName)
        {
            //###############################################################
            // Season/Episode (S01E01)

            Regex rSE = new Regex("[Ss]([0-9]+)[Ee]([0-9]+)");
            Match mSE = rSE.Match(fileName);
            if (mSE.Success)
            {
                Regex rT = new Regex("(.+)" + mSE.ToString());
                Match mT = rT.Match(fileName);
                if (mT.Success)
                {
                    Title = mT.Groups[1].Value;
                    Title = Title.Replace('.', ' ').Replace('_', ' ');
                    Title = Title.TrimEnd(new char[] { ' ', '-', '.' });

                    Season = int.Parse(mSE.Groups[1].Value);
                    Episode = int.Parse(mSE.Groups[2].Value);
                }

                return;
            }

            //###############################################################
            // Season/Episode (1x01)

            Regex rX = new Regex("([0-9]+)[Xx]([0-9]+)");
            Match mX = rX.Match(fileName);
            if (mX.Success)
            {
                Regex rT = new Regex("(.+)" + mX.ToString());
                Match mT = rT.Match(fileName);
                if (mT.Success)
                {
                    Title = mT.Groups[1].Value;
                    Title = Title.Replace('.', ' ').Replace('_', ' ');
                    Title = Title.TrimEnd(new char[] { ' ', '-', '.' });

                    Season = int.Parse(mX.Groups[1].Value);
                    Episode = int.Parse(mX.Groups[2].Value);
                }

                return;
            }

            //###############################################################
            // BTV [Title-(EpisodeTitle)-0000-00-00-0.tp]
            // Date (0000.00.00) (0000-00-00)

            Regex rDateYMD_BTV = new Regex(@"([12][09][0-9][0-9])[\.\-]([0-1][0-9])[\.\-]([0-3][0-9])");
            Match mDateYMD_BTV = rDateYMD_BTV.Match(fileName);
            if (mDateYMD_BTV.Success)
            {
                Regex rT = new Regex("(.+)" + mDateYMD_BTV.ToString());
                Match mT = rT.Match(fileName);
                if (mT.Success)
                {
                    Regex rE = new Regex("(.+)-[(](.+)[)]");
                    Title = mT.Groups[1].Value;
                    Match mE = rE.Match(Title);
                    if (mE.Success)
                    {
                        Title = mE.Groups[1].Value;
                        EpisodeTitle = mE.Groups[2].Value;
                    }
                    Title = Title.Replace('.', ' ').Replace('_', ' ');
                    Title = Title.TrimEnd(new char[] { ' ', '-', '.' });

                    OriginalAirDate = new DateTime(int.Parse(mDateYMD_BTV.Groups[1].Value), int.Parse(mDateYMD_BTV.Groups[2].Value), int.Parse(mDateYMD_BTV.Groups[3].Value));
                }

                return;
            }

            //###############################################################
            // Date (0000.00.00) (0000-00-00)

            Regex rDateYMD = new Regex(@"([12][09][0-9][0-9])[\.\-]([0-1][0-9])[\.\-]([0-3][0-9])");
            Match mDateYMD = rDateYMD.Match(fileName);
            if (mDateYMD.Success)
            {
                Regex rT = new Regex("(.+)" + mDateYMD.ToString());
                Match mT = rT.Match(fileName);
                if (mT.Success)
                {
                    Title = mT.Groups[1].Value;
                    Title = Title.Replace('.', ' ').Replace('_', ' ');
                    Title = Title.TrimEnd(new char[] { ' ', '-', '.' });

                    OriginalAirDate = new DateTime(int.Parse(mDateYMD.Groups[1].Value), int.Parse(mDateYMD.Groups[2].Value), int.Parse(mDateYMD.Groups[3].Value));
                }

                return;
            }

            //###############################################################
            // Date (00.00.0000) (00-00-0000)

            Regex rDateMDY = new Regex(@"([0-1][0-9])[\.\-]([0-3][0-9])[\.\-]([12][09][0-9][0-9])");
            Match mDateMDY = rDateMDY.Match(fileName);
            if (mDateMDY.Success)
            {
                Regex rT = new Regex("(.+)" + mDateMDY.ToString());
                Match mT = rT.Match(fileName);
                if (mT.Success)
                {
                    Title = mT.Groups[1].Value;
                    Title = Title.Replace('.', ' ').Replace('_', ' ');
                    Title = Title.TrimEnd(new char[] { ' ', '-', '.' });

                    OriginalAirDate = new DateTime(int.Parse(mDateMDY.Groups[3].Value), int.Parse(mDateMDY.Groups[1].Value), int.Parse(mDateMDY.Groups[2].Value));
                }

                return;
            }

            //###############################################################
            // Part (Part01)

            Regex rP = new Regex("part.?([0-9]+)", RegexOptions.IgnoreCase);
            Match mP = rP.Match(fileName);
            if (mP.Success)
            {
                Regex rT = new Regex("(.+)" + mP.ToString());
                Match mT = rT.Match(fileName);
                if (mT.Success)
                {
                    Title = mT.Groups[1].Value;
                    Title = Title.Replace('.', ' ').Replace('_', ' ');
                    Title = Title.TrimEnd(new char[] { ' ', '-', '.' });

                    Season = 1;
                    Episode = int.Parse(mP.Groups[1].Value);
                }

                return;
            }
        }
    }
}
