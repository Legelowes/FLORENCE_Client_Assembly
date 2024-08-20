using FLORENCE_Client.FrameworkSpace;

namespace FLORENCE_Client
{
    public class Program
    {
        private static FLORENCE_Client.Framework framework;

        public static void Main(String[] args)
        {
            System.Console.WriteLine("FLORENCE START");
            framework = new FLORENCE_Client.Framework();
            while (framework == null) { /* wait untill created */ }
            framework.Get_Client().Get_Execute().Create_And_Run_Graphics();
        }

        public static FLORENCE_Client.Framework Get_Framework() 
        { 
            return framework; 
        }
    }
}

