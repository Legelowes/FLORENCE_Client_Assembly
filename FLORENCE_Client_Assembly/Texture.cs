using System;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

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
                        public class Texture
                        {
                            private static int Handle = 0;

                            public Texture(string path_To_Image)
                            {
                                Set_Handle( GL.GenTexture() );
                                Use();
                                StbImage.stbi_set_flip_vertically_on_load(1);
                                ImageResult image = ImageResult.FromStream(
                                    File.OpenRead(path_To_Image), 
                                    ColorComponents.RedGreenBlueAlpha
                                );
                                GL.TexImage2D(
                                    TextureTarget.Texture2D, 
                                    0, 
                                    PixelInternalFormat.Rgba, 
                                    image.Width, 
                                    image.Height, 
                                    0, 
                                    PixelFormat.Rgba, 
                                    PixelType.UnsignedByte, 
                                    image.Data
                                );

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

                                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                            }

                            public void Use()
                            {
                                GL.BindTexture(TextureTarget.Texture2D, Get_Handle());
                            }

                            public int Get_Handle()
                            {
                                return Handle;
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
