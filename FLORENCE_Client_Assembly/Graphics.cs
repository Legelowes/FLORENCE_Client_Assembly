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
                public class Graphics : GameWindow
                {
                    public Graphics() : base(
                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings.GetGameWindowSettings(),
                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings.GetNativeWindowSettings()
                    )
                    {
                        base.Run();
                    }

                    protected override void OnUpdateFrame(FrameEventArgs e)
                    {
                        base.OnUpdateFrame(e);

                        if (KeyboardState.IsKeyDown(Keys.Escape))
                        {
                            base.Close();
                        }
                    }
                }
            }
        }
    }
}
