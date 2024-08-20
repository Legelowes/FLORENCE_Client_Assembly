using FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

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
                    //private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics graphics;

                    private static float[] vertices = {
                          // positions        // colors
                          0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 0.0f,   // bottom right
                         -0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f,   // bottom left
                          0.0f,  0.5f, 0.0f,  0.0f, 0.0f, 1.0f    // top 
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
                        System.Console.WriteLine("FLORENCE: Output");
                    }
                    public void Initalise_Graphics()
                    {
                        using (var graphics = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Graphics(
                            FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Settings().GetGameWindowSettings(),
                            FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Settings().GetNativeWindowSettings()
                        ))
                        {
                            FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings.Set_systemInitialised( true );
                            graphics.Run();
                        }
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
