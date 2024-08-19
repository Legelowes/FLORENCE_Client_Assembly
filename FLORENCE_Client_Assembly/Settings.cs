
using OpenTK.Windowing.Desktop;

namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            namespace DataSpace
            {
                public class Settings
                {
                    private static OpenTK.Windowing.Desktop.GameWindowSettings gws = OpenTK.Windowing.Desktop.GameWindowSettings.Default;
                    private static OpenTK.Windowing.Desktop.NativeWindowSettings nws = OpenTK.Windowing.Desktop.NativeWindowSettings.Default;
                    private static int refreshRate = 60;

                    public Settings()
                    {
                        while (gws == null) { /* wait untill created */ }
                        while (nws == null) { /* wait untill created */ }
                        Set_refreshRate(60);

                        gws.UpdateFrequency = Get_refreshRate();

                        nws.IsEventDriven = false;
                        nws.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
                        nws.APIVersion = Version.Parse(input: "4.1");
                        nws.AutoLoadBindings = true;
                        nws.Location = new OpenTK.Mathematics.Vector2i(x: 100, y: 100);
                        nws.ClientSize = new OpenTK.Mathematics.Vector2i(x: 1280, y: 720);
                        nws.StartFocused = true;
                        nws.StartVisible = true;
                        nws.Title = "FLORENCE";
                    }

                    public GameWindowSettings GetGameWindowSettings()
                    {
                        return gws;
                    }

                    public NativeWindowSettings GetNativeWindowSettings()
                    {
                        return nws;
                    }

                    public int Get_refreshRate()
                    {
                        return refreshRate;
                    }

                    public void Set_refreshRate(int value)
                    {
                        refreshRate = value;
                    }
                }
            }
        }
    }
}