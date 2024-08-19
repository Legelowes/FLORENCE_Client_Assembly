
using System.ComponentModel;

namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            public class Data
            {
                private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings settings = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings();
                private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Input input = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Input();
                private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Output output = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Output();
                private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Map_Default map_Default = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Map_Default();

                public Data()
                {
                    
                    while (settings == null) { /* wait untill created */ }
        
                    while (input == null) { /* wait untill created */ }
       
                    while (output == null) { /* wait untill created */ }
   
                    while (map_Default == null) { /* wait untill created */ }
                }

                public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings Get_Settings()
                {
                    return settings;
                }

                public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Input Get_Input()
                {
                    return input;
                }

                public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Output Get_Output()
                {
                    return output;
                }

                public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Map_Default Get_Map_Default()
                {
                    return map_Default;
                }
            }
        }
    }
}
