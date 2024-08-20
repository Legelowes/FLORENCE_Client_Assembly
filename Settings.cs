
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
                    private OpenTK.Windowing.Desktop.GameWindowSettings gws;
                    private OpenTK.Windowing.Desktop.NativeWindowSettings nws;

                    private static int refreshRate = 60;
                    private static bool systemInitialised = false;

                    public Settings()
                    {
                        System.Console.WriteLine("FLORENCE: Settings");
                        this.gws = OpenTK.Windowing.Desktop.GameWindowSettings.Default;
                        while (this.gws == null) { /* wait untill created */ }
                        this.nws = OpenTK.Windowing.Desktop.NativeWindowSettings.Default;
                        while (this.nws == null) { /* wait untill created */ }
                        this.Set_refreshRate(60);
                        this.gws.UpdateFrequency = this.Get_refreshRate();
                        this.nws.IsEventDriven = false;
                        this.nws.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
                        this.nws.APIVersion = Version.Parse(input: "4.1");
                        this.nws.AutoLoadBindings = true;
                        this.nws.Location = new OpenTK.Mathematics.Vector2i(x: 100, y: 100);
                        this.nws.ClientSize = new OpenTK.Mathematics.Vector2i(x: 1280, y: 720);
                        this.nws.StartFocused = true;
                        this.nws.StartVisible = true;
                        this.nws.Title = "FLORENCE";
                    }

                    public GameWindowSettings GetGameWindowSettings()
                    {
                        return this.gws;
                    }

                    public NativeWindowSettings GetNativeWindowSettings()
                    {
                        return this.nws;
                    }

                    public int Get_refreshRate()
                    {
                        return refreshRate;
                    }

                    public static bool Get_systemInitialised()
                    {
                        return systemInitialised;

                    }
                    public void Set_refreshRate(int value)
                    {
                        refreshRate = value;
                    }
                    
                    public static void Set_systemInitialised(bool value)
                    {
                        systemInitialised = value;
                    }
                }
            }
        }
    }
}