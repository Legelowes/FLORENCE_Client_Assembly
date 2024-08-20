
namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            public class Execute
            {
                
                private Thread listen_To_Server;

                public Execute()
                {
                    System.Console.WriteLine("FLORENCE: Execute");
                    this.listen_To_Server = new Thread(FLORENCE_Client.FrameworkSpace.ClientSpace.Algorithms.Thread_Listen_To_Server);
                    while (this.listen_To_Server == null) { /* wait untill created */ }
                    this.listen_To_Server.Start();
                }

                public void Create_And_Run_Graphics()
                {
                    FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Output().Initalise_Graphics();
                }
            }
        }
    }
}
