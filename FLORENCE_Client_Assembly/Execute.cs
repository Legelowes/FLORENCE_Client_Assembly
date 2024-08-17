
namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            public class Execute
            {
                
                private static Thread listen_To_Server;

                public Execute()
                {
                    FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Initalise_Graphics();

                    listen_To_Server = new Thread(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms.Thread_Listen_To_Server);
                    while (listen_To_Server == null) { /* wait untill created */ }
                    listen_To_Server.Start();
                }


            }
        }
    }
}
