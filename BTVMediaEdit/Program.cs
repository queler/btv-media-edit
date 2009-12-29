/****************************************************************************
 * 
 * File:  Program.cs
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BTVMediaEdit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
            {
                if (arg.Split('=')[0].ToLower().Equals("/u"))
                {
                    string guid = arg.Split('=')[1];
                    string sysPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    ProcessStartInfo psi = new ProcessStartInfo(sysPath + "\\msiexec.exe", "/i " + guid);
                    Process.Start(psi);
                    Application.Exit();
                    return;
                }
            }

#if DEBUG
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BTVMediaEdit());
#else
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BTVMediaEdit());
            }
            catch (Exception ex)
            {
                try
                {
                    string excFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
                        String.Format("BTVMediaEdit_{0}.exc", DateTime.Now.ToString("yyyyMMddHHmmss")));

                    StreamWriter excFileStream = new StreamWriter(excFilePath);
                    excFileStream.WriteLine(ex.Message);
                    excFileStream.WriteLine(ex.StackTrace);
                    excFileStream.Flush();
                    excFileStream.Close();

                    MessageBox.Show(String.Format("Exception written to {0}\n\nExiting.", excFilePath), "Exception",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
#endif
        }
    }
}
