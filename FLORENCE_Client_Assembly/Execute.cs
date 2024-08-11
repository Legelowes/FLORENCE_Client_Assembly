using FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace;
using OpenTK.Windowing.Desktop;

namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            public class Execute
            {
                private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace.Graphics graphics;
                private static Thread listen_To_Server;

                public Execute()
                {
                    graphics = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace.Graphics();
                    while (graphics == null) { /* wait untill created */ }
                    FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace.Graphics.Initialise_Control();

                    listen_To_Server = new Thread(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.Algorithms.Thread_Listen_To_Server);
                    while (listen_To_Server == null) { /* wait untill created */ }
                    listen_To_Server.Start();
                }

                public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace.Graphics Get_Graphics()
                {
                    return graphics;
                }
            }
        }
    }
}
