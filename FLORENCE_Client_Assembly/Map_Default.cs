using OpenTK.Graphics.OpenGL4;
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
                        public static Double[][] hexagon_Tile;
                        public static int radius = 10;

                        public Map_Default()
                        {
                            hexagon_Tile = new Double[6][];
                            hexagon_Tile[0] = [1,       0                           ];
                            hexagon_Tile[1] = [0.5,     (System.Math.Cbrt(3) / 2)   ];
                            hexagon_Tile[2] = [-0.5,    (System.Math.Cbrt(3) / 2)   ];
                            hexagon_Tile[3] = [-1,      0                           ];
                            hexagon_Tile[4] = [-0.5,    (-System.Math.Cbrt(3) / 2)  ];
                            hexagon_Tile[5] = [0.5,     (-System.Math.Cbrt(3) / 2)  ];
                        }

                        public static void Draw_Tile()
                        {
                            GL.UseProgram(FLORENCE_Client_Assembly.FrameworkSpace.ClientSpace.DataSpace.OutputSpace.Shader.Get_Handle());
                            float[] vertices = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            for (int i = 0; i < 5; i++)
                            {
                                vertices[0] = (float)hexagon_Tile[i][0];
                                vertices[1] = (float)hexagon_Tile[i][1];
                                vertices[2] = (float)0;

                                vertices[3] = (float)hexagon_Tile[i+1][0];
                                vertices[4] = (float)hexagon_Tile[i+1][1];
                                vertices[5] = (float)0;

                                vertices[6] = (float)0;
                                vertices[7] = (float)0;
                                vertices[8] = (float)0;

                                GL.BufferData(
                                    BufferTarget.ArrayBuffer,
                                    vertices.Length * sizeof(float),
                                    vertices,
                                    BufferUsageHint.StreamDraw
                                );

                                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
                            }
                        }

                        public static Double[][] Get_Vertices()
                        {
                            return hexagon_Tile;
                        }
                    }
                }
            }
        }
    }
}

