using OpenTK.Graphics.OpenGL4;

namespace FLORENCE_Client
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            namespace DataSpace
            {
                namespace OutputSpace
                {
                    namespace GraphicsSpace
                    {
                        public class Shader
                        {
                            private bool disposedValue = false;
                            private static int Handle = 0;
                            private static int FragmentShader = 0;
                            private static int VertexShader = 0;
                            private static string FragmentShaderSource = "..\\..\\..\\shader_frag.txt";
                            private static string VertexShaderSource = "..\\..\\..\\shader_vert.txt";
                            
                            public Shader(string vertexPath, string fragmentPath)
                            {
                                VertexShaderSource = File.ReadAllText(vertexPath);
                                FragmentShaderSource = File.ReadAllText(fragmentPath);

                                VertexShader = GL.CreateShader(ShaderType.VertexShader);
                                GL.ShaderSource(VertexShader, VertexShaderSource);

                                FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
                                GL.ShaderSource(FragmentShader, FragmentShaderSource);

                                GL.CompileShader(VertexShader);

                                GL.GetShader(VertexShader, ShaderParameter.CompileStatus, out int success_a);
                                if (success_a == 0)
                                {
                                    string infoLog = GL.GetShaderInfoLog(VertexShader);
                                    Console.WriteLine(infoLog);
                                }

                                GL.CompileShader(FragmentShader);

                                GL.GetShader(FragmentShader, ShaderParameter.CompileStatus, out int success_b);
                                if (success_b == 0)
                                {
                                    string infoLog = GL.GetShaderInfoLog(FragmentShader);
                                    Console.WriteLine(infoLog);
                                }

                                Handle = GL.CreateProgram();

                                GL.AttachShader(Handle, VertexShader);
                                GL.AttachShader(Handle, FragmentShader);

                                GL.LinkProgram(Handle);

                                GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int success_c);
                                if (success_c == 0)
                                {
                                    string infoLog = GL.GetProgramInfoLog(Handle);
                                    Console.WriteLine(infoLog);
                                }

                                GL.DetachShader(Handle, VertexShader);
                                GL.DetachShader(Handle, FragmentShader);
                                GL.DeleteShader(FragmentShader);
                                GL.DeleteShader(VertexShader);

                                GL.TexParameter(
                                    TextureTarget.Texture2D,
                                    TextureParameterName.TextureWrapS,
                                    (int)TextureWrapMode.Repeat
                                );
                                GL.TexParameter(
                                    TextureTarget.Texture2D,
                                    TextureParameterName.TextureWrapT,
                                    (int)TextureWrapMode.Repeat
                                );

                                GL.TexParameter(
                                    TextureTarget.Texture2D,
                                    TextureParameterName.TextureMinFilter,
                                    (int)TextureMinFilter.Nearest
                                );
                                GL.TexParameter(
                                    TextureTarget.Texture2D,
                                    TextureParameterName.TextureMagFilter,
                                    (int)TextureMagFilter.Linear
                                );

                                GL.TexParameter(
                                    TextureTarget.Texture2D,
                                    TextureParameterName.TextureMinFilter,
                                    (int)TextureMinFilter.LinearMipmapLinear
                                );
                                GL.TexParameter(
                                    TextureTarget.Texture2D,
                                    TextureParameterName.TextureMagFilter,
                                    (int)TextureMagFilter.Linear
                                );
                            }

                            ~Shader()
                            {
                                Dispose();
                                if (disposedValue == false)
                                {
                                    Console.WriteLine("GPU Resource leak! Did you forget to call Dispose()?");
                                }
                            }
                            /*
                            public int GetAttribLocation(string attribName)
                            {
                                return GL.GetAttribLocation(Handle, attribName);
                            }
                            */
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
                                GC.SuppressFinalize(this);
                            }

                            public int Get_Handle()
                            {
                                return Handle;
                            }

                            public void Use()
                            {
                                GL.UseProgram(Handle);
                            }

                            public void Set_Handle(int value)
                            {
                                Handle = value;
                            }
                        }
                    }
                }
            }
        }
    }
}
