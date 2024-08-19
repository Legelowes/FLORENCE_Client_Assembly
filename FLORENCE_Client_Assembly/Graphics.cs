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
                        private static int VertexBufferObject;
                        private static int VertexArrayObject;
                        private static int ElementBufferObject;

                        private static int nrAttributes;
                        private static double periodOfRefresh;
                        private static float greenValue;

                         public Graphics(OpenTK.Windowing.Desktop.GameWindowSettings gws, OpenTK.Windowing.Desktop.NativeWindowSettings nws) : base(
                            gws,
                            nws
                        )
                        {
                            base.Run();
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
                            switch (FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings.Get_systemInitialised())
                            {
                                case false:
                                    base.OnLoad();
                                    GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                                    break;
                                    
                                case true:
                                    base.OnLoad();

                                    GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

                                    VertexBufferObject = GL.GenBuffer();
                                    GL.BindBuffer(
                                        BufferTarget.ArrayBuffer,
                                        VertexBufferObject
                                    );
                                    GL.BufferData(
                                        BufferTarget.ArrayBuffer,
                                        FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Output().Get_Vertices().Length * sizeof(float),
                                        FLORENCE_Client.Program.Get_Framework().Get_Client().Get_Data().Get_Output().Get_Vertices(),
                                        BufferUsageHint.StreamDraw
                                    );
                                    //Code goes here

                                    break;
                            }
                        }

                        protected override void OnRenderFrame(FrameEventArgs e)
                        {
                            base.OnRenderFrame(e);

                            GL.Clear(ClearBufferMask.ColorBufferBit);

                            //Code goes here.

                            SwapBuffers();
                        }

                        protected override void OnUpdateFrame(FrameEventArgs e)
                        {
                            base.OnUpdateFrame(e);

                            if (KeyboardState.IsKeyDown(Keys.Escape))
                            {
                                Close();
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
