using OpenTK.Graphics.OpenGL4;

namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            namespace DataSpace
            {
                namespace OutputSpace
                {
                    public class Shader
                    {
                        private bool disposedValue = false;
                        public static int Handle = 0;
                        public static string VertexShaderSource = "..\\..\\..\\shader_vert.txt";
                        public static string FragmentShaderSource = "..\\..\\..\\shader_frag.txt";
                        
                        public Shader()
                        {

                        }

                        ~Shader()
                        {
                            Dispose();
                            if (disposedValue == false)
                            {
                                Console.WriteLine("GPU Resource leak! Did you forget to call Dispose()?");
                            }
                        }

                        public static void Initialise(string vertexPath, string fragmentPath)
                        {
                            VertexShaderSource = File.ReadAllText(vertexPath);
                            FragmentShaderSource = File.ReadAllText(fragmentPath);
                        }
                        protected virtual void Dispose(bool disposing)
                        {
                            if (!disposedValue)
                            {
                                GL.DeleteProgram(Handle);

                                disposedValue = true;
                            }
                        }

                        public void Dispose()
                        {
                            Dispose(true);
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Dispose_Shader();
                            GC.SuppressFinalize(this);
                        }

                        public static void Use()
                        {
                            GL.UseProgram(Handle);
                        }

                        public static void Set_Handle(int value)
                        {
                            Handle = value;
                        }
                    }
                }
            }
        }
    }
}
