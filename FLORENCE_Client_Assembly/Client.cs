namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        public class Client
        {
            private FLORENCE_Client.FrameworkSpace.ClientSpace.Algorithms algorothms;
            private FLORENCE_Client.FrameworkSpace.ClientSpace.Data data;
            private FLORENCE_Client.FrameworkSpace.ClientSpace.Execute execute;

            public Client()
            {
                System.Console.WriteLine("FLORENCE: Client");
                this.algorothms = new FLORENCE_Client.FrameworkSpace.ClientSpace.Algorithms();
                while (this.algorothms == null) { /* wait untill created */ }
                this.data = new FLORENCE_Client.FrameworkSpace.ClientSpace.Data();
                while (this.data == null) { /* wait untill created */ }
                this.execute = new FLORENCE_Client.FrameworkSpace.ClientSpace.Execute();
                while (this.execute == null) { /* wait untill created */ }
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