
namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            public class Execute
            {
                
                private static Thread? listen_To_Server;

                public Execute()
                {
                    listen_To_Server = new Thread(FLORENCE_Client.FrameworkSpace.ClientSpace.Algorithms.Thread_Listen_To_Server);
                    while (listen_To_Server == null) { /* wait untill created */ }
                    listen_To_Server.Start();
                }

                public void Initialise_Client(FLORENCE_Client.FrameworkSpace.Client ptr_client)
                {
                    ptr_client.Get_Data().Get_Output().Initalise_Graphics(ptr_client.Get_Data());
                }

            }
        }
    }
}
