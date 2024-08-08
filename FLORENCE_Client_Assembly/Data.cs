
namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            public class Data
            {
                public Data()
                {
                    ptr_Input = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Input();
                    while (ptr_Input == null) { /* wait untill created */ }
                    ptr_Output = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output();
                    while (ptr_Output == null) { /* wait untill created */ }
                }

                public FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Input get_Input()
                {
                    return ptr_Input;
                }
                public FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output get_Output()
                {
                    return ptr_Output;
                }

                private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Input ptr_Input;
                private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output ptr_Output;
            }
        }
    }
}
