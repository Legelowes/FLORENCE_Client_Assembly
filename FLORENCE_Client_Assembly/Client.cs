namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        public class Client
        {
            private FLORENCE_Client.FrameworkSpace.ClientSpace.Algorithms algorothms = new FLORENCE_Client.FrameworkSpace.ClientSpace.Algorithms();
            private FLORENCE_Client.FrameworkSpace.ClientSpace.Data data = new FLORENCE_Client.FrameworkSpace.ClientSpace.Data();
            private FLORENCE_Client.FrameworkSpace.ClientSpace.Execute execute = new FLORENCE_Client.FrameworkSpace.ClientSpace.Execute();

            public Client()
            {
                
                while (algorothms == null) { /* wait untill created */ }
                
                while (data == null) { /* wait untill created */ }
                
                while (execute == null) { /* wait untill created */ }
            }

            public FLORENCE_Client.FrameworkSpace.ClientSpace.Algorithms Get_Algorithms()
            {
                return algorothms;
            }

            public FLORENCE_Client.FrameworkSpace.ClientSpace.Data Get_Data()
            {
                return data;
            }

            public FLORENCE_Client.FrameworkSpace.ClientSpace.Execute Get_Execute()
            {
                return execute;
            }
        }
    }
}