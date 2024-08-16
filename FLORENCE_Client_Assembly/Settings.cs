
using OpenTK.Windowing.Desktop;

namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            namespace DataSpace
            {
                public class Settings
                {
                    private static OpenTK.Windowing.Desktop.GameWindowSettings gws;
                    private static OpenTK.Windowing.Desktop.NativeWindowSettings nws;
                    private static int refreshRate = new int();

                    public Settings()
                    {
                        gws = OpenTK.Windowing.Desktop.GameWindowSettings.Default;
                        nws = OpenTK.Windowing.Desktop.NativeWindowSettings.Default;
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

                    public static GameWindowSettings GetGameWindowSettings()
                    {
                        return gws;
                    }

                    public static NativeWindowSettings GetNativeWindowSettings()
                    {
                        return nws;
                    }

                    public static int Get_refreshRate()
                    {
                        return refreshRate;
                    }

                    public static void Set_refreshRate(int value)
                    {
                        refreshRate = value;
                    }
                }
            }
        }
    }
}