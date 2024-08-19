using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using StbImageSharp;
using System.IO;

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
                        private FLORENCE_Client.FrameworkSpace.ClientSpace.Data data;
                        private static FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader shader = 
                            new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader(
                                "..\\..\\..\\shader_frag.txt",
                                "..\\..\\..\\shader_vert.txt"
                            );
                        private static FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture[] textureArray = {
                            new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture("..\\..\\..\\Textures\\null_default.png")
                        };

                        private static int VertexBufferObject;
                        private static int VertexArrayObject;
                        private static int ElementBufferObject;

                        private static int nrAttributes;
                        private static double periodOfRefresh;
                        private static float greenValue;

                         public Graphics(FLORENCE_Client.FrameworkSpace.ClientSpace.Data data_pass) : base(
                            data_pass.Get_Settings().GetGameWindowSettings(),
                            data_pass.Get_Settings().GetNativeWindowSettings()
                        )
                        {
                            data = data_pass;
                            base.Run();
                            
                            nrAttributes = 0;
                            GL.GetInteger(GetPName.MaxVertexAttribs, out nrAttributes);

                            shader = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader(
                                "..\\..\\..\\shader_frag.txt",
                                "..\\..\\..\\shader_vert.txt"
                            );
                            while (shader == null) { /* wait untill created */ }

                            textureArray = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture[nrAttributes];
                            for (int i = 0; i < nrAttributes; i++)
                            {
                                textureArray[i] = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture(
                                    "..\\..\\..\\Textures\\null_default.png"
                                );
                                while (textureArray[i] == null) { /* wait untill created */ }
                            }
                            
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
                                data.Get_Output().Get_Vertices().Length * sizeof(float),
                                data.Get_Output().Get_Vertices(), 
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
                            
                            shader = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader(
                                "..\\..\\..\\shader_vert.txt",
                                "..\\..\\..\\shader_frag.txt"
                            );
                            shader.Use();
// draw square \/ \/ \/
                            ElementBufferObject = GL.GenBuffer();
                            GL.BindBuffer(
                                BufferTarget.ElementArrayBuffer, 
                                ElementBufferObject
                            );
                            GL.BufferData(
                                BufferTarget.ElementArrayBuffer,
                                data.Get_Output().Get_Indices().Length * sizeof(uint),
                                data.Get_Output().Get_Indices(), 
                                BufferUsageHint.StreamDraw
                            );
// draw square /\ /\ /\
                            Console.WriteLine("Maximum number of vertex attributes supported: " + nrAttributes);

                            textureArray[0] = new FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Texture("..\\..\\..\\Textures\\container.jpg");
                            textureArray[0].Use();
                            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

                            GL.ActiveTexture(TextureUnit.Texture0);
                            GL.BindTexture(TextureTarget.Texture2D, textureArray[0].Get_Handle());
                            //Code goes here

                        }

                        protected override void OnRenderFrame(FrameEventArgs e)
                        {
                            base.OnRenderFrame(e);

                            GL.Clear(ClearBufferMask.ColorBufferBit);
                            shader.Use();
                        
                            greenValue = Get_New_greenValue();
                            
                            int vertexColorLocation = GL.GetUniformLocation(
                                Get_Shader().Get_Handle(),
                                "ourColor"
                            );
                            GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);


                            // now render the triangle
                            GL.BindVertexArray(VertexArrayObject);
                            data.Get_Map_Default().Draw_Square(data);
                            //data.Get_Map_Default().Draw_Triangle();


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
                        
                        public FLORENCE_Client.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.GraphicsSpace.Shader Get_Shader()
                        {
                            return shader;
                        }
                    }
                }
            }
        }
    }
}
