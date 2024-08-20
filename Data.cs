
using System.ComponentModel;

namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            public class Data
            {
                private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings settings;
                private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Input input;
                private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Output output;
                private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Map_Default map_Default;

                public Data()
                {
                    System.Console.WriteLine("FLORENCE: Data");
                    this.settings = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings();
                    while (this.settings == null) { /* wait untill created */ }
                    this.input = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Input();
                    while (this.input == null) { /* wait untill created */ }
                    this.output = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Output();
                    while (this.output == null) { /* wait untill created */ }
                    this.map_Default = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Map_Default();
                    while (this.map_Default == null) { /* wait untill created */ }
                }

                public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings Get_Settings()
                {
                    return this.settings;
                }

                public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Input Get_Input()
                {
                    return this.input;
                }

                public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Output Get_Output()
                {
                    return this.output;
                }

                public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Map_Default Get_Map_Default()
                {
                    return this.map_Default;
                }
            }
        }
    }
}
