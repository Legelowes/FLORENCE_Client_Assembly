
using FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace;

namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    { 
        public class Client
        {
            public Client()
            {
                ptr_Algorothms = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms();
                while (ptr_Algorothms == null) { /* wait untill created */ }
                ptr_Data = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data();
                while (ptr_Data == null) { /* wait untill created */ }
                ptr_Execute = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute();
                while (ptr_Execute == null) { /* wait untill created */ }
            }

            public FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms get_Algorithms()
            {
                return ptr_Algorothms;
            }
            public FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data get_Data()
            {
                return ptr_Data;
            }
            public FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute get_Execute()
            {
                return ptr_Execute;
            }

            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms ptr_Algorothms;
            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Data ptr_Data;
            private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Execute ptr_Execute;
        }  
    }
}
