﻿using Microsoft.VisualBasic.FileIO;

namespace FLORENCE_Client
{
    public class Framework
    {
        private FLORENCE_Client.FrameworkSpace.Client client = new FLORENCE_Client.FrameworkSpace.Client();

        public Framework()
        {
            this.client = new FLORENCE_Client.FrameworkSpace.Client();
            while (this.client == null) { /* wait untill created */ }

            
            //TODO Netorking
        }

        public FLORENCE_Client.FrameworkSpace.Client Get_Client()
        {
            return this.client;
        }
    }
}
