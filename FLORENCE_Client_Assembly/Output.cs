
namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            namespace DataSpace
            {
                public class Output
                {
                    public Output()
                    {
                        ptr_GFX = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GFX();
                        while (ptr_GFX == null) { /* wait untill created */ }
                    }

                    public FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GFX get_GFX()
                    {
                        return ptr_GFX;
                    }

                    private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GFX ptr_GFX;
                }
            }
        }
    }
}