
using FLORENCE_Client_Assembly.FrameworkSpace;

namespace FLORENCE_Client_Assembly
{
    public class Framework
    {
        public Framework() 
        {
            ptr_Client = new FLORENCE_Client_Assembly.FrameworkSpace.Client();
            while (ptr_Client == null) { /* wait untill created */ }
            //TODO Netorking
        }

        public FLORENCE_Client_Assembly.FrameworkSpace.Client get_Client()
        {
            return ptr_Client;
        }

        private static FLORENCE_Client_Assembly.FrameworkSpace.Client ptr_Client;
    }
}
