using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using graphicLibTest.Resources.Textures;
using graphicLibTest.Resources.View;
using graphicLibTest.Resources.Sprite;

namespace Game1
{
    class Game : GameWindow
    {
        Texture2D texture;
        View view;

        public Game(int width, int height)
            : base(width, height)
        {
            GL.Enable(EnableCap.Texture2D);

            view = new View(Vector2.Zero, 1, 0.0);

            MouseDown += Mouse_ButtonDown;
        }

        void Mouse_ButtonDown(object sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            Vector2 pos = new Vector2(e.Position.X, e.Position.Y);
            pos -= new Vector2(this.Width, this.Height) / 2f;
            pos = view.ToWorld(pos);

            view.SetPosition(pos, TweenType.QuarticOut, 60);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            texture = ContentPipe.LoadTexture("il_fullxfull.1152887108_9y04.jpg");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            view.Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.CornflowerBlue);

            SpriteBatch.Begin(this.Width, this.Height);
            view.ApplyTransform();

            SpriteBatch.Draw(texture, Vector2.Zero, new Vector2(0.2f, 0.2f), Color.Green, new Vector2(10, 50));
            SpriteBatch.Draw(texture, new Vector2(100, 10), new Vector2(0.2f, 0.2f), Color.Red, new Vector2(10, 50));
            SpriteBatch.Draw(texture, new Vector2(200, 30), new Vector2(0.2f, 0.2f), Color.Orange, new Vector2(10, 50));
            SpriteBatch.Draw(texture, new Vector2(300, 30), new Vector2(0.2f, 0.2f), Color.Blue, new Vector2(10, 50));

            this.SwapBuffers();
        }
    }
}