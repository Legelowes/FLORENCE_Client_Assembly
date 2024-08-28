using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

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
                    public class Graphics : GameWindow
                    {
                        private int ElementBufferObject;
                        private int VertexArrayObject;
                        private int VertexBufferObject;
                        private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader shader;
                        private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture texture0;
                        private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture texture1;

                        private static int nrAttributes;
                        private static double periodOfRefresh;

                        public Graphics(OpenTK.Windowing.Desktop.GameWindowSettings gws, OpenTK.Windowing.Desktop.NativeWindowSettings nws) : base(
                           gws,
                           nws
                       )
                        {
                            System.Console.WriteLine("FLORENCE: Graphics & GameWindow");
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

                            VertexArrayObject = GL.GenVertexArray();
                            GL.BindVertexArray(VertexArrayObject);

                            VertexBufferObject = GL.GenBuffer();
                            GL.BindBuffer(
                                BufferTarget.ArrayBuffer, 
                                VertexBufferObject
                            );
                            GL.BufferData(
                                BufferTarget.ArrayBuffer,
                                FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Output().Get_Vertices().Length * sizeof(float),
                                FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Output().Get_Vertices(), 
                                BufferUsageHint.StaticDraw
                            );

                            // draw square \/ \/ \/
                            ElementBufferObject = GL.GenBuffer();
                            GL.BindBuffer(
                                BufferTarget.ElementArrayBuffer,
                                ElementBufferObject
                            );
                            GL.BufferData(
                                BufferTarget.ElementArrayBuffer,
                                FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Output().Get_Indices().Length * sizeof(uint),
                                FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Output().Get_Indices(),
                                BufferUsageHint.StaticDraw
                            );
                            // draw square /\ /\ /\

                            shader = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader(
                                "..\\..\\..\\shader_vert.glsl",
                                "..\\..\\..\\shader_frag.glsl"
                            );
                            shader.Use();

                            GL.VertexAttribPointer(
                                0, 
                                3, 
                                VertexAttribPointerType.Float, 
                                false, 
                                5 * sizeof(float), 
                                0
                            );
                            GL.EnableVertexAttribArray(0);

                            GL.VertexAttribPointer(
                                1, 
                                3, 
                                VertexAttribPointerType.Float, 
                                false, 
                                5 * sizeof(float), 
                                3 * sizeof(float)
                            );
                            GL.EnableVertexAttribArray(1);

                            texture0 = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture("..\\..\\..\\Textures\\container.jpg");
                            texture0.Use(TextureUnit.Texture0);

                            texture1 = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture("..\\..\\..\\Textures\\awesomeface.png");
                            texture1.Use(TextureUnit.Texture1);

                            nrAttributes = 0;
                            GL.GetInteger(GetPName.MaxVertexAttribs, out nrAttributes);
                            Console.WriteLine("Maximum number of vertex attributes supported: " + nrAttributes);

                            shader.SetInt("texture0", 0);
                            shader.SetInt("texture1", 1);

                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
                            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                        }

                        protected override void OnRenderFrame(FrameEventArgs e)
                        {
                            base.OnRenderFrame(e);

                            GL.Clear(ClearBufferMask.ColorBufferBit);

                            GL.BindVertexArray(VertexArrayObject);

                            var transform = Matrix4.Identity;

                            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90.0f));

                            transform = transform * Matrix4.CreateScale(0.5f, 0.5f, 0.5f);

                            transform = transform * Matrix4.CreateTranslation(0.1f, 0.1f, 0.0f);

                            texture0.Use(TextureUnit.Texture0);
                            texture1.Use(TextureUnit.Texture1);
                            shader.Use();

                            shader.SetMatrix4("transform", transform);
/*
// change colour with time \/ \/ \/
                            float greenValue = Get_New_greenValue();
                            int vertexColorLocation = GL.GetUniformLocation(shader.Get_Handle(), "ourColor");
                            GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);
// change colour with time /\ /\ /\
*/
                            //FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Map_Default().Draw_Triangle();
                            FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Map_Default().Draw_Square(FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data());
                            
                            SwapBuffers();
                        }

                        protected override void OnUnload()
                        {
                            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                            GL.BindVertexArray(0);
                            GL.UseProgram(0);

                            // Delete all the resources.
                            GL.DeleteBuffer(VertexBufferObject);
                            GL.DeleteVertexArray(VertexArrayObject);

                            GL.DeleteProgram(shader.Get_Handle());

                            shader.Dispose();

                            base.OnUnload();
                        }

                        protected override void OnUpdateFrame(FrameEventArgs e)
                        {
                            base.OnUpdateFrame(e);
                            if (KeyboardState.IsKeyDown(Keys.Escape))
                            {
                                this.Close();
                            }
                        }

                        public static float Get_New_greenValue()
                        {
                            periodOfRefresh += 0.0166666666666667;//period per frame - settings gws.UpdateFrequency = 60
                            if (periodOfRefresh == 2000) periodOfRefresh = 0;
                            return (float)Math.Sin(periodOfRefresh) / (2.0f + 0.5f);
                        }
                    }
                }
            }
        }
    }
}
