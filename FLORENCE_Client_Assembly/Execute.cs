
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
                    this.listen_To_Server = new Thread(FLORENCE_Client.FrameworkSpace.ClientSpace.Algorithms.Thread_Listen_To_Server);
                    while (this.listen_To_Server == null) { /* wait untill created */ }
                    this.listen_To_Server.Start();
                }
            }
        }
    }
}
