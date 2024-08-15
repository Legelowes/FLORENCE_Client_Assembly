using OpenTK.Graphics.OpenGL4;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

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
                    public class Map_Default
                    {
                        public static int amountOfDots = 6;
                        public static Double[] hexagon_Tile;
                        public static int radius = 10;

                        public Map_Default()
                        {
                            hexagon_Tile = new Double[21];

                            hexagon_Tile[0] = (Double)0;
                            hexagon_Tile[1] = (Double)0;
                            hexagon_Tile[2] = (Double)0;

                            hexagon_Tile[3] = (Double)1;
                            hexagon_Tile[4] = (Double)0;
                            hexagon_Tile[5] = (Double)0;

                            hexagon_Tile[6] = (Double)0.5;
                            hexagon_Tile[7] = (Double)(System.Math.Cbrt(3) / 2);
                            hexagon_Tile[8] = (Double)0;

                            hexagon_Tile[9] = (Double)(-0.5);
                            hexagon_Tile[10] = (Double)(System.Math.Cbrt(3) / 2);
                            hexagon_Tile[11] = (Double)0;

                            hexagon_Tile[12] = (Double)(-1);
                            hexagon_Tile[13] = (Double)0;
                            hexagon_Tile[14] = (Double)0;

                            hexagon_Tile[15] = (Double)(-0.5);
                            hexagon_Tile[16] = (Double)(-System.Math.Cbrt(3) / 2);
                            hexagon_Tile[17] = (Double)0;

                            hexagon_Tile[18] = (Double)0.5;
                            hexagon_Tile[19] = (Double)(-System.Math.Cbrt(3) / 2);
                            hexagon_Tile[20] = (Double)0;
                        }

                        public static void Draw_Tile()
                        {
                            GL.UseProgram(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Get_Handle());
                            GL.BindVertexArray(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.Output.Get_VertexArrayObject());
                            float[] vertices = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            for (int i = 0; i < 6; i++)
                            {
                                vertices[0] = (float)hexagon_Tile[0];
                                vertices[1] = (float)hexagon_Tile[1];
                                vertices[2] = (float)hexagon_Tile[2];

                                vertices[3] = (float)hexagon_Tile[(i * 3) + 3];
                                vertices[4] = (float)hexagon_Tile[(i * 3) + 4];
                                vertices[5] = (float)hexagon_Tile[(i * 3) + 5];

                                if (i != 5)
                                {
                                    vertices[6] = (float)hexagon_Tile[(i * 3) + 6];
                                    vertices[7] = (float)hexagon_Tile[(i * 3) + 7];
                                    vertices[8] = (float)hexagon_Tile[(i * 3) + 8];
                                }
                                else
                                {
                                    vertices[6] = (float)hexagon_Tile[3];
                                    vertices[7] = (float)hexagon_Tile[4];
                                    vertices[8] = (float)hexagon_Tile[5];
                                }
                                GL.BufferData(
                                    BufferTarget.ArrayBuffer,
                                    vertices.Length * sizeof(float),
                                    vertices,
                                    BufferUsageHint.StreamDraw
                                );

                                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
                            }
                        }

                        public static Double[] Get_Vertices()
                        {
                            return hexagon_Tile;
                        }
                    }
                }
            }
        }
    }
}

