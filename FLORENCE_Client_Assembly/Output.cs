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
                    private static int ElementBufferObject;
                    private static double timeValue;
                    private static int VertexArrayObject;
                    private static int VertexBufferObject;
                    private static float[] vertices_OLD = {
                        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
                         0.5f, -0.5f, 0.0f, //Bottom-right vertex
                         0.0f,  0.5f, 0.0f  //Top vertex
                    };
                    private static float[] vertices = {
                         0.5f,  0.5f, 0.0f,  // top right
                         0.5f, -0.5f, 0.0f,  // bottom right
                        -0.5f, -0.5f, 0.0f,  // bottom left
                        -0.5f,  0.5f, 0.0f   // top left
                    };
                    private static uint[] indices_square = {  // note that we start from 0!
                        0, 1, 3,   // first triangle
                        1, 2, 3    // second triangle
                    };
                    private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader shader;
                    

                    public Output()
                    {
                        timeValue = 0;
                        shader = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader(
                            "..\\..\\..\\shader_vert.txt",
                            "..\\..\\..\\shader_frag.txt"
                        );
                        while (shader == null) { /* wait untill created */ }

                    }

                    public static void Dispose_Shader()
                    {
                        shader.Dispose();
                    }


                    public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader Get_Shader()
                    {
                        return shader;
                    }

                    public static int Get_ElementBufferObject()
                    {
                        return ElementBufferObject;
                    }
                    
                    public static uint[] Get_Indices_Square()
                    {
                        return indices_square;
                    }

                    public static float Get_New_greenValue()
                    {
                        timeValue += 0.0166666666666667;//period per frame - settings gws.UpdateFrequency = 60
                        if (timeValue == 2000) timeValue = 0;
                        return (float)Math.Sin(timeValue) / (2.0f + 0.5f);
                    }

                    public static int Get_VertexArrayObject()
                    {
                        return VertexArrayObject;
                    }

                    public static int Get_VertexBufferObject()
                    {
                        return VertexBufferObject;
                    }

                    public static float[] Get_Vertices()
                    {
                        return vertices;
                    }

                    public static void Set_ElementBufferObject(int value)
                    {
                        ElementBufferObject = value;
                    }

                    public static void Set_VertexArrayObject(int value)
                    {
                        VertexArrayObject = value;
                    }

                    public static void Set_VertexBufferObject(int value)
                    {
                        VertexBufferObject = value;
                    }
                }
            }
        }
    }
}
