namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        public class Client
        {
            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms ptr_Algorothms;
            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data ptr_Data;
            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute ptr_Execute;

            public Client()
            {
                ptr_Algorothms = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms();
                while (ptr_Algorothms == null) { /* wait untill created */ }
                ptr_Data = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data();
                while (ptr_Data == null) { /* wait untill created */ }
                ptr_Execute = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute();
                while (ptr_Execute == null) { /* wait untill created */ }
            }
            public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms Get_Algorithms()
            {
                return ptr_Algorothms;
            }
            public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data Get_Data()
            {
                return ptr_Data;
            }
            public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute Get_Execute()
            {
                return ptr_Execute;
            }
        }
    }
}