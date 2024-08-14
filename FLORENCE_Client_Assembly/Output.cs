using OpenTK.Graphics.OpenGL4;
using System.ComponentModel;

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
                    private static int VertexArrayObject;
                    private static int VertexBufferObject;
                    private static float[] vertices = {
                        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
                         0.5f, -0.5f, 0.0f, //Bottom-right vertex
                         0.0f,  0.5f, 0.0f  //Top vertex
                    };
                    private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader shader;
                    

                    public Output()
                    {
                        shader = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader();
                        while (shader == null) { /* wait untill created */ }

                    }

                    public static void Dispose_Shader()
                    {
                        shader.Dispose();
                    }


                    public static void DrawPolygon(System.Drawing.Point[] points)
                    {
                        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

                    }

                    public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader Get_Shader()
                    {
                        return shader;
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
