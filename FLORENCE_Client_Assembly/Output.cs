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
                        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
                         0.5f, -0.5f, 0.0f, //Bottom-right vertex
                         0.0f,  0.5f, 0.0f  //Top vertex
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
                        this.graphics = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics(
                            FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings.GetGameWindowSettings4Boot(),
                            FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings.GetNativeWindowSettings4Boot()
                        );
                    }

                    public void Initalise_Graphics(FLORENCE_Client.FrameworkSpace.ClientSpace.Data data_pass)
                    {
                        this.graphics = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics(
                            FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Settings().GetGameWindowSettings(),
                            FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Settings().GetNativeWindowSettings()
                        );
                        while (this.graphics == null) { /* wait untill created */ }
                    }

                    public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics Get_Graphics()
                    {
                        return this.graphics;
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
