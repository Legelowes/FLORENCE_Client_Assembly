using FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace;
using OpenTK.Graphics.OpenGL4;

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
                    private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics graphics;

                    private static float[] vertices = {
                         0.5f,  0.5f, 0.0f,  // top right
                         0.5f, -0.5f, 0.0f,  // bottom right
                        -0.5f, -0.5f, 0.0f,  // bottom left
                        -0.5f,  0.5f, 0.0f   // top left
                    };
                    private static uint[] indices = {  // note that we start from 0!
                        0, 1, 3,   // first triangle
                        1, 2, 3    // second triangle
                    };
                    public static void Initalise_Graphics()
                    {
                        graphics = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics();
                        while (graphics == null) { /* wait untill created */ }
                    }

                    public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics Get_Graphics()
                    {
                        return graphics;
                    }

                    public static uint[] Get_Indices()
                    {
                        return indices;
                    }

                    public static float[] Get_Vertices()
                    {
                        return vertices;
                    }
                }
            }
        }
    }
}
