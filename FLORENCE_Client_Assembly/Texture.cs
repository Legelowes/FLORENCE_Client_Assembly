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
                            int Handle;

                            public Texture(string path_To_File)
                            {
                                Handle = GL.GenTexture();
                                GL.BindTexture(TextureTarget.Texture2D, Handle);

                                StbImage.stbi_set_flip_vertically_on_load(1);

                                ImageResult image = ImageResult.FromStream(File.OpenRead(path_To_File), ColorComponents.RedGreenBlueAlpha);

                                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);

                                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                            }
                        }
                    }
                }
            }
        }
    }
}
