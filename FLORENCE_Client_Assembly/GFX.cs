using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

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
                        public GFX()
                        {
                            GameWindowSettings gws = GameWindowSettings.Default;
                            NativeWindowSettings nws = NativeWindowSettings.Default;

                            gws.UpdateFrequency = 60;

                            nws.APIVersion = Version.Parse(input: "4.1.0");
                            nws.Size = new Vector2i(x: 1280, y: 720);
                            nws.Title = "FLORENCE";

                            GameWindow window = new GameWindow(gws, nws);

                            window.Run();
                        }
                    }
                }
            }
        }
    }
}