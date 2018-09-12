using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using graphicLibTest.Resources.Textures;

namespace graphicLibTest.Resources.Sprite
{
    class SpriteBatch
    {
        public static void Draw(Texture2D texture, Vector2 position, Vector2 scale, Color color, Vector2 origin)
        {
            Vector2[] verticies = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1),
            };

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(color);
            for (int i = 0; i < 4; i++)
            {
                GL.TexCoord2(verticies[i]);

                verticies[i].X *= texture.Width;
                verticies[i].Y *= texture.Height;
                verticies[i] -= origin;
                verticies[i] *= scale;
                verticies[i] += position;

                GL.Vertex2(verticies[i]);
            }

            GL.End();
        }

        public static void Begin(int screenWidth, int screenHeight)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-screenWidth / 2f, screenWidth / 2f, screenHeight / 2f, -screenHeight / 2, 0f, 1f);
        }
    }
}
