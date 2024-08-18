using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using StbImageSharp;
using System.IO;

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
                    public class Graphics : GameWindow
                    {
                        private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader shader;
                        private static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture texture;

                        private static int VertexBufferObject;
                        private static int VertexArrayObject;
                        private static int ElementBufferObject;

                        private static double periodOfRefresh;
                        private static float greenValue;

                         public Graphics() : base(
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings.GetGameWindowSettings(),
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings.GetNativeWindowSettings()
                        )
                        {
                            base.Run();
                            shader = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader(
                                "..\\..\\..\\shader_vert.txt",
                                "..\\..\\..\\shader_frag.txt"
                            );
                            while (shader == null) { /* wait untill created */ }
                        }
                        
                        ~Graphics()
                        {

                        }

                        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
                        {
                            base.OnFramebufferResize(e);

                            GL.Viewport(0, 0, e.Width, e.Height);
                        }

                        protected override void OnLoad()
                        {
                            base.OnLoad();

                            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                            VertexBufferObject = GL.GenBuffer();
                            GL.BindBuffer(
                                BufferTarget.ArrayBuffer, 
                                VertexBufferObject
                            );
                            GL.BufferData(
                                BufferTarget.ArrayBuffer,
                                FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Vertices().Length * sizeof(float),
                                FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Vertices(), 
                                BufferUsageHint.StreamDraw
                            );

                            VertexArrayObject = GL.GenVertexArray();
                            GL.BindVertexArray(VertexArrayObject);
                            GL.VertexAttribPointer(
                                0, 
                                3, 
                                VertexAttribPointerType.Float, 
                                false, 
                                5 * sizeof(float), 
                                0
                            );
                            GL.EnableVertexAttribArray(0);

                            //int texCoordLocation = shader.GetAttribLocation("aTexCoord");
                            GL.VertexAttribPointer(
                                1, 
                                2, 
                                VertexAttribPointerType.Float, 
                                false, 
                                5 * sizeof(float), 
                                3 * sizeof(float)
                            );
                            GL.EnableVertexAttribArray(1);
                            
                            shader = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader(
                                "..\\..\\..\\shader_vert.txt",
                                "..\\..\\..\\shader_frag.txt"
                            );
                            shader.Use();
/*
                            ElementBufferObject = GL.GenBuffer();
                            GL.BindBuffer(
                                BufferTarget.ElementArrayBuffer, 
                                ElementBufferObject
                            );
                            GL.BufferData(
                                BufferTarget.ElementArrayBuffer,
                                FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Indices().Length * sizeof(uint), 
                                FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Indices(), 
                                BufferUsageHint.StreamDraw
                            );
*/
                            int nrAttributes = 0;
                            GL.GetInteger(GetPName.MaxVertexAttribs, out nrAttributes);
                            Console.WriteLine("Maximum number of vertex attributes supported: " + nrAttributes);

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

                            texture = new FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture("..\\..\\..\\Textures\\container.jpg");
                            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                            //Code goes here

                        }

                        protected override void OnRenderFrame(FrameEventArgs e)
                        {
                            base.OnRenderFrame(e);

                            GL.Clear(ClearBufferMask.ColorBufferBit);
                            shader.Use();
                        
                            greenValue = Get_New_greenValue();
                            int vertexColorLocation = GL.GetUniformLocation(
                                FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader.Get_Handle(),
                                "ourColor"
                            );
                            GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);


                            // now render the triangle
                            GL.BindVertexArray(VertexArrayObject);
                            //FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Map_Default.Draw_Square();
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Map_Default.Draw_Triangle();


                            //Code goes here.
                            SwapBuffers();
                        }

                        protected override void OnUpdateFrame(FrameEventArgs e)
                        {
                            base.OnUpdateFrame(e);

                            if (KeyboardState.IsKeyDown(Keys.Escape))
                            {
                                Close();
                                Dispose_Shader();
                                base.Dispose();
                            }
                        }

                        public static void Dispose_Shader()
                        {
                            shader.Dispose();
                        }
                        
                        public static float Get_New_greenValue()
                        {
                            periodOfRefresh += 0.0166666666666667;//period per frame - settings gws.UpdateFrequency = 60
                            if (periodOfRefresh == 2000) periodOfRefresh = 0;
                            return (float)Math.Sin(periodOfRefresh) / (2.0f + 0.5f);
                        }
                        
                        public static FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader Get_Shader()
                        {
                            return shader;
                        }
                    }
                }
            }
        }
    }
}
