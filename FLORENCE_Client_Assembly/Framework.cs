namespace FLORENCE_Client_Assembly
{
    public class Framework
    {
        private static FLORENCE_Client_Assembly.FrameworkSpace.Client client;

        public Framework()
        {
            FLORENCE_Client_Assembly.FrameworkSpace.Client client = new FLORENCE_Client_Assembly.FrameworkSpace.Client();
            while (client == null) { /* wait untill created */ }
            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms.Thread_IO();
            //TODO Netorking
        }

        public static FLORENCE_Client_Assembly.FrameworkSpace.Client Get_Client()
        {
            return client;
        }
    }
}
