
using System.ComponentModel;

namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            public class Data
            {
                private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Input input;
                private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output output;
                private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings settings;
                private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Map_Default map_Default;

                public Data()
                {
                    settings = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings();
                    while (settings == null) { /* wait untill created */ }
                    input = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Input();
                    while (input == null) { /* wait untill created */ }
                    output = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output();
                    while (output == null) { /* wait untill created */ }
                    map_Default = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Map_Default();
                    while (map_Default == null) { /* wait untill created */ }
                }

                public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings Get_Settings()
                {
                    return settings;
                }
                public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Input Get_Input()
                {
                    return input;
                }
                public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output Get_Output()
                {
                    return output;
                }
                public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Map_Default Get_Map_Default()
                {
                    return map_Default;
                }
            }
        }
    }
}
