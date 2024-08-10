namespace FLORENCE_Client_Assembly
{
    public class Framework
    {
        private static FLORENCE_Client_Assembly.FrameworkSpace.Client ptr_Client;

        public Framework()
        {
            FLORENCE_Client_Assembly.FrameworkSpace.Client ptr_Client = new FLORENCE_Client_Assembly.FrameworkSpace.Client();
            while (ptr_Client == null) { /* wait untill created */ }
            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms.Thread_Do_Graphics();
            //TODO Netorking
        }

        public static FLORENCE_Client_Assembly.FrameworkSpace.Client Get_Client()
        {
            return ptr_Client;
        }
    }
}
