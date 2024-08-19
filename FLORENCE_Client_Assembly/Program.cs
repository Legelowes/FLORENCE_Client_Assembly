namespace FLORENCE_Client
{
    public class Program
    {
        private static FLORENCE_Client.Framework framework = new FLORENCE_Client.Framework();

        public static void Main(String[] args)
        {
            System.Console.WriteLine("FLORENCE START");
            while (framework == null) { /* wait untill created */ }
        }

        public static FLORENCE_Client.Framework Get_Framework() 
        { 
            return framework; 
        }
    }
}

