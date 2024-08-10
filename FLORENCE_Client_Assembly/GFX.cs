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
            namespace DataSpace
            {
                namespace OutputSpace
                {
                    public class GFX
                    {
                        private static OpenTK.Windowing.Desktop.GameWindow window;
                        private static OpenTK.Windowing.Desktop.GameWindowSettings gws;
                        private static OpenTK.Windowing.Desktop.NativeWindowSettings nws;

                        public GFX()
                        {

                        }

                        public static void Create_And_Start_3D_Graphics()
                        {
                            gws = OpenTK.Windowing.Desktop.GameWindowSettings.Default;
                            nws = OpenTK.Windowing.Desktop.NativeWindowSettings.Default;

                            gws.UpdateFrequency = 60;
                            
                            nws.IsEventDriven = false;
                            nws.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
                            nws.APIVersion = Version.Parse(input: "4.1");
                            nws.AutoLoadBindings = true;
                            nws.Location = new OpenTK.Mathematics.Vector2i(x: 100, y: 100);
                            nws.ClientSize = new OpenTK.Mathematics.Vector2i(x: 1280, y: 720);
                            nws.StartFocused = true;
                            nws.StartVisible = true;
                            nws.Title = "FLORENCE"; 

                            window = new OpenTK.Windowing.Desktop.GameWindow(gws, nws);
                            window.Run();
                        }
                    }
                }
            }
        }
    }
}
