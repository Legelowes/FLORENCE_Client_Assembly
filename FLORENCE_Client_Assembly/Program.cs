using System;

namespace FLORENCE_Client_Assembly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("FLORENCE START");
            FLORENCE_Client_Assembly.Framework ptr_Framework = new FLORENCE_Client_Assembly.Framework();
        }

        public static FLORENCE_Client_Assembly.Framework GetFramework()
        {
            return ptr_Framework;
        }

        private static FLORENCE_Client_Assembly.Framework ptr_Framework;
    }
}

