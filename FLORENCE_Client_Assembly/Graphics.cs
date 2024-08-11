using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            namespace ExecuteSpace
            {
                public class GameWindow
                {
                    public GameWindow()
                    {
                        
                    }
                }
                public class Graphics : GameWindow
                {
                    private static OpenTK.Windowing.Desktop.GameWindow gameWindow;

                    public Graphics() : base()
                    {

                    }

                    public static void Create_And_Start_3D_Graphics()
                    {
                        gameWindow = new OpenTK.Windowing.Desktop.GameWindow(
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace.GraphicsSpace.Control_Of_Graphics.GetGameWindowSettings(),
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace.GraphicsSpace.Control_Of_Graphics.GetNativeWindowSettings()
                        );
                        gameWindow.Run();
                    }

                    public static void Initialise_Control()
                    {
                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace.GraphicsSpace.Control_Of_Graphics control_Of_Graphics = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.ExecuteSpace.GraphicsSpace.Control_Of_Graphics();
                    }

                    public static OpenTK.Windowing.Desktop.GameWindow Get_GameWindow()
                    {
                        return gameWindow;
                    }
                }
            }
        }
    }
}
