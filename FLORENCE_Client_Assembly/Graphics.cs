using FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Reflection.Metadata;

namespace FLORENCE_Client_Assembly
{
    namespace FrameworkSpace
    {
        namespace ClientSpace
        {
            namespace ExecuteSpace
            {
                public class Graphics : GameWindow
                {
                    public Graphics() : base(
                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings.GetGameWindowSettings(),
                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Settings.GetNativeWindowSettings()
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
                        base.OnLoad();

                        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Set_VertexBufferObject(GL.GenBuffer());
                        GL.BindBuffer(
                            BufferTarget.ArrayBuffer, 
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_VertexBufferObject()
                        );
                        GL.BufferData(
                            BufferTarget.ArrayBuffer, 
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Vertices().Length * sizeof(float), 
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Vertices(), 
                            BufferUsageHint.StreamDraw
                        );

                        var VertexShader = GL.CreateShader(ShaderType.VertexShader);
                        GL.ShaderSource(VertexShader, FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.VertexShaderSource);

                        var FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
                        GL.ShaderSource(FragmentShader, FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.FragmentShaderSource);

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

                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Set_Handle(GL.CreateProgram());

                        GL.AttachShader(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Handle, VertexShader);
                        GL.AttachShader(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Handle, FragmentShader);

                        GL.LinkProgram(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Handle);

                        GL.GetProgram(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Handle, GetProgramParameterName.LinkStatus, out int success);
                        if (success == 0)
                        {
                            string infoLog = GL.GetProgramInfoLog(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Handle);
                            Console.WriteLine(infoLog);
                        }

                        GL.DetachShader(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Handle, VertexShader);
                        GL.DetachShader(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Handle, FragmentShader);
                        GL.DeleteShader(FragmentShader);
                        GL.DeleteShader(VertexShader);

                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Set_VertexArrayObject(OpenTK.Graphics.OpenGL4.GL.GenVertexArray());
                        OpenTK.Graphics.OpenGL4.GL.BindVertexArray(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_VertexArrayObject());
                        GL.BindBuffer(
                            BufferTarget.ArrayBuffer, 
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_VertexBufferObject()
                        );
                        GL.BufferData(
                            BufferTarget.ArrayBuffer,
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Vertices().Length * sizeof(float), 
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Vertices(), 
                            BufferUsageHint.StreamDraw
                        );
                        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
                        GL.EnableVertexAttribArray(0);

                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Set_ElementBufferObject(GL.GenBuffer());
                        GL.BindBuffer(
                            BufferTarget.ElementArrayBuffer, 
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_ElementBufferObject()
                        );
                        GL.BufferData(
                            BufferTarget.ElementArrayBuffer,
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Indices_Square().Length * sizeof(uint),
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Indices_Square(), 
                            BufferUsageHint.StreamDraw
                        );

                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Use();
                        //Code goes here
                    }

                    protected override void OnRenderFrame(FrameEventArgs e)
                    {
                        base.OnRenderFrame(e);
                        GL.Clear(ClearBufferMask.ColorBufferBit);

                        //Code goes here.
                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Use();

                        
                        float greenValue = FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_New_greenValue();
                        int vertexColorLocation = GL.GetUniformLocation(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Get_Handle(), "ourColor");
                        GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);

                        FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Map_Default.Draw_Tile();
                        /*
                        GL.DrawElements(
                            PrimitiveType.Triangles,
                            FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_Indices_Square().Length, 
                            DrawElementsType.UnsignedInt, 
                            0
                        );
                        */
                        Context.SwapBuffers();
                        
                    }

                    protected override void OnUpdateFrame(FrameEventArgs e)
                    {
                        base.OnUpdateFrame(e);

                        if (KeyboardState.IsKeyDown(Keys.Escape))
                        {
                            Close();
                            base.Dispose();
                        }
                    }
                }
            }
        }
    }
}
