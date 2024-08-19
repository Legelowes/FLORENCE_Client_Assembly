using FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace;
using OpenTK.Graphics.OpenGL4;

namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            namespace DataSpace
            {
                public class Output
                {
                    private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics graphics;

                    private static float[] vertices = {
                        //Position          Texture coordinates
                        0.5f,  0.5f, 0.0f, 1.0f, 1.0f, // top right
                        0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // bottom right
                        -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // bottom left
                        -0.5f,  0.5f, 0.0f, 0.0f, 1.0f  // top left
                    };
                    private static uint[] indices = {  // note that we start from 0!
                        0, 1, 3,   // first triangle
                        1, 2, 3    // second triangle
                    };
                    private static float[] texCoords = {
                        0.0f, 0.0f,  // lower-left corner  
                        1.0f, 0.0f,  // lower-right corner
                        0.5f, 1.0f   // top-center corner
                    };

                    public Output()
                    {

                    }

                    public void Initalise_Graphics(FLORENCE_Client.FrameworkSpace.ClientSpace.Data data_pass)
                    {
                        graphics = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics(data_pass);
                        while (graphics == null) { /* wait untill created */ }
                    }

                    public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics Get_Graphics()
                    {
                        return graphics;
                    }

                    public uint[] Get_Indices()
                    {
                        return indices;
                    }

                    public float[] Get_Vertices()
                    {
                        return vertices;
                    }
                }
            }
        }
    }
}
