using Microsoft.VisualBasic.FileIO;

namespace FLORENCE_Client
{
    public class Framework
    {
        private static FLORENCE_Client.FrameworkSpace.Client client;

        public Framework()
        {
            client = new FLORENCE_Client.FrameworkSpace.Client();
            while (client == null) { /* wait untill created */ }

            client.Get_Execute().Initialise_Client(client);
            //TODO Netorking
        }

        public static FLORENCE_Client.FrameworkSpace.Client Get_Client()
        {
            return client;
        }
    }
}
