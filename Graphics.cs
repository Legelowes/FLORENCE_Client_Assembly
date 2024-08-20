using FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
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
                namespace OutputSpace
                {
                    public class Graphics : GameWindow
                    {
                        private readonly float[] vertices = {
                            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
                             0.5f, -0.5f, 0.0f, //Bottom-right vertex
                             0.0f,  0.5f, 0.0f  //Top vertex
                        };
                        
                        private int VertexArrayObject;
                        private int VertexBufferObject;
                        private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader shader;
                        //private int ElementBufferObject;

                        private static int nrAttributes;
                        private static double periodOfRefresh;
                        private static float greenValue;

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
                            VertexBufferObject = GL.GenBuffer();
                            GL.BindVertexArray(VertexBufferObject);
                            
                            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
                            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

                            VertexArrayObject = GL.GenVertexArray();
                            GL.BindVertexArray(VertexArrayObject);

                            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
                            GL.EnableVertexAttribArray(0);
                      
                            shader = new Shader(
                                "C:\\Users\\Brenton Maddocks\\source\\repos\\FLORENCE_Client_Assembly\\FLORENCE_Client_Assembly\\shader_vert.glsl", 
                                "C:\\Users\\Brenton Maddocks\\source\\repos\\FLORENCE_Client_Assembly\\FLORENCE_Client_Assembly\\shader_frag.glsl");
                            shader.Use();
                        }

                        protected override void OnRenderFrame(FrameEventArgs e)
                        {
                            base.OnRenderFrame(e);
                            GL.Clear(ClearBufferMask.ColorBufferBit);
                            shader.Use();
                            GL.BindVertexArray(VertexArrayObject);
                            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
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
