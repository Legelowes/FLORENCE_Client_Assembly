
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

                public Data()
                {
                    input = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Input();
                    while (input == null) { /* wait untill created */ }
                    output = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output();
                    while (output == null) { /* wait untill created */ }
                }

                public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Input Get_Input()
                {
                    return input;
                }
                public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output Get_Output()
                {
                    return output;
                }
            }
        }
    }
}
