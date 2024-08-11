namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        public class Client
        {
            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms algorothms;
            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data data;
            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute execute;

            public Client()
            {
                algorothms = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms();
                while (algorothms == null) { /* wait untill created */ }
                data = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data();
                while (data == null) { /* wait untill created */ }
                execute = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute();
                while (execute == null) { /* wait untill created */ }
            }
            public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms Get_Algorithms()
            {
                return algorothms;
            }
            public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data Get_Data()
            {
                return data;
            }
            public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute Get_Execute()
            {
                return execute;
            }
        }
    }
}