/****************************************************************************
 * 
 * File:  Startup.cs
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
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace BTVMediaEdit
{
    public class Startup
    {
        private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static void SetAutoStart(string keyName, string exeLocation)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.SetValue(keyName, exeLocation);
        }

        public static void UnSetAutoStart(string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.DeleteValue(keyName);
        }

        public static bool IsAutoStartEnabled(string keyName, string exeLocation)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
            if (key == null)
            {
                return false;
            }

            string value = (string)key.GetValue(keyName);
            if (value == null)
            {
                return false;
            }

            return (value == exeLocation);
        }
    }
}
