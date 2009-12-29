﻿/****************************************************************************
 * 
 * File:  TvDb.cs
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
using System.Windows.Forms;

namespace BTVMediaEdit
{
    static class TvDb
    {
        public const string TVDB_API_KEY = "593F29EDEB3FFDDA";

        public static string GetCachePath()
        {
            string cachePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "cache");
            
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }

            return cachePath;
        }
    }
}