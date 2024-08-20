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
                        //private FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader shader;

                        private int VertexBufferObject;
                        private int VertexArrayObject;
                        //private int ElementBufferObject;

                        private static int nrAttributes;
                        private static double periodOfRefresh;
                        private static float greenValue;

                        public Graphics(OpenTK.Windowing.Desktop.GameWindowSettings gws, OpenTK.Windowing.Desktop.NativeWindowSettings nws) : base(
                           gws,
                           nws
                       )
                        {
                            //this.shader = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader("\\..\\..\\..\\shader_vert.glsl", "\\..\\..\\..\\shader_frag.glsl");
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
                            switch (FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings.Get_systemInitialised())
                            {
                                case false:
                                {
                                    GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                                }
                                break;

                                case true:
                                {
                                     GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                                }
                                break;
                            }
                        }

                        protected override void OnRenderFrame(FrameEventArgs e)
                        {
                            base.OnRenderFrame(e);
                            switch (FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings.Get_systemInitialised())
                            {
                                case false:
                                    {

                                    }
                                    break;

                                case true:
                                    {
                                        GL.Clear(ClearBufferMask.ColorBufferBit);

                                        //Code goes here.

                                        this.SwapBuffers();
                                    }
                                    break;
                            }
                        }

                        protected override void OnUnload()
                        {
                            base.OnUnload();
                        }

                        protected override void OnUpdateFrame(FrameEventArgs e)
                        {
                            base.OnUpdateFrame(e);
                            switch (FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.Settings.Get_systemInitialised())
                            {
                                case false:
                                    {

                                    }
                                    break;

                                case true:
                                    {
                                        if (KeyboardState.IsKeyDown(Keys.Escape))
                                        {
                                            this.Close();
                                        }
                                    }
                                    break;
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
