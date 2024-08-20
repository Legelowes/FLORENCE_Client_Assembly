
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
                    
                    private static OpenTK.Windowing.Desktop.GameWindowSettings gws_4_Boot;
                    private static OpenTK.Windowing.Desktop.NativeWindowSettings nws_4_Boot;

                    private static int refreshRate = 60;
                    private static int refreshRate_4_Boot = 1;
                    private static bool systemInitialised = false;

                    public Settings()
                    {
                        gws_4_Boot = OpenTK.Windowing.Desktop.GameWindowSettings.Default;
                        while (gws_4_Boot == null) { /* wait untill created */ }
                        nws_4_Boot = OpenTK.Windowing.Desktop.NativeWindowSettings.Default;
                        while (nws_4_Boot == null) { /* wait untill created */ }
                        Set_refreshRate_4_Boot(1);
                        gws_4_Boot.UpdateFrequency = this.Get_refreshRate_4_Boot();
                        nws_4_Boot.IsEventDriven = false;
                        nws_4_Boot.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
                        nws_4_Boot.APIVersion = Version.Parse(input: "4.1");
                        nws_4_Boot.AutoLoadBindings = true;
                        nws_4_Boot.Location = new OpenTK.Mathematics.Vector2i(x: 0, y: 0);
                        nws_4_Boot.ClientSize = new OpenTK.Mathematics.Vector2i(x: 100, y: 100);
                        nws_4_Boot.StartFocused = true;
                        nws_4_Boot.StartVisible = true;
                        nws_4_Boot.Title = "Loading";

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

                    public static GameWindowSettings GetGameWindowSettings4Boot()
                    {
                        return gws_4_Boot;
                    }

                    public static NativeWindowSettings GetNativeWindowSettings4Boot()
                    {
                        return nws_4_Boot;
                    }

                    public int Get_refreshRate()
                    {
                        return refreshRate;
                    }

                    public int Get_refreshRate_4_Boot()
                    {
                        return refreshRate_4_Boot;

                    }

                    public static bool Get_systemInitialised()
                    {
                        return systemInitialised;

                    }
                    public void Set_refreshRate(int value)
                    {
                        refreshRate = value;
                    }
                    
                    public void Set_refreshRate_4_Boot(int value)
                    {
                        refreshRate_4_Boot = value;
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