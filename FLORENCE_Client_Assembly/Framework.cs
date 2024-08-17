using Microsoft.VisualBasic.FileIO;

namespace FLORENCE_Client_Assembly
{
    public class Framework
    {
        private static FLORENCE_Client_Assembly.FrameworkSpace.Client client;

        public Framework()
        {
            client = new FLORENCE_Client_Assembly.FrameworkSpace.Client();
            while (client == null) { /* wait untill created */ }
            //TODO Netorking
        }

        public static FLORENCE_Client_Assembly.FrameworkSpace.Client Get_Client()
        {
            return client;
        }
    }
}
