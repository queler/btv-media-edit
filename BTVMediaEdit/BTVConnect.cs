/****************************************************************************
 * 
 * File:  BTVConnect.cs
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
using System.Timers;

namespace BTVMediaEdit
{
    using BTVServer;

    public class BTVConnect
    {
        public string AuthTicket = String.Empty;

        private BTVLicenseManagerSoapClient btvLicenseManager = null;
        private System.Timers.Timer renewTimer = new System.Timers.Timer();
        private bool isConnected = false;

        //###################################################################

        public BTVConnect()
        {
            renewTimer.Elapsed += new ElapsedEventHandler(renewTimer_Elapsed);
        }

        public void Logon(string address, string port, string user, string password)
        {
            btvLicenseManager = new BTVLicenseManagerSoapClient("BTVLicenseManagerSoap",
                String.Format("http://{0}:{1}/wsdl/BTVLicenseManager.asmx", address, port));
            PVSPropertyBag t = btvLicenseManager.Logon("", user, password);

            foreach (PVSProperty p in t.Properties)
            {
                if (p.Name.Equals("AuthTicket"))
                {
                    AuthTicket = p.Value;
                    break;
                }
            }

            renewTimer.Interval = 800000;
            renewTimer.Start();

            isConnected = true;
        }

        public void Logoff()
        {
            renewTimer.Stop();
            btvLicenseManager.Logoff(AuthTicket);
            isConnected = false;
        }

        public bool IsConnected()
        {
            return isConnected;
        }

        //###################################################################

        private void renewTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            btvLicenseManager.RenewLogonSession(AuthTicket);
        }
    }
}
