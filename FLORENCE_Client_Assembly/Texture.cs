using System;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

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
                    namespace GraphicsSpace
                    {
                        public class Texture
                        {
                            private static int Handle;

                            public Texture(string path_To_Image)
                            {
                                Handle = GL.GenTexture();
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
                                
                            }

                            public static void Use()
                            {
                                GL.BindTexture(TextureTarget.Texture2D, Handle);
                            }
                        }
                    }
                }
            }
        }
    }
}
