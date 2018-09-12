using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace lvlprevew
{
    class Game : GameWindow
    {
        public Game(int width, int height, GraphicsMode mode, string title, GameWindowFlags options)
            : base(width, height, mode, title, options)
        {
            MouseDown += Mouse_ButtonDown;
        }

        void Mouse_ButtonDown(object sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            Game Window1 = new Game(1280, 729, null, "Window1", GameWindowFlags.FixedWindow);

            double fps = 60;
            Window1.VSync = VSyncMode.Adaptive;

            Window1.Run(fps, fps);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.FromArgb(15, 15, 15, 15));

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.FromArgb(255, 0, 0));
            GL.Vertex2(0, 0);
            GL.Color3(Color.FromArgb(0, 255, 0));
            GL.Vertex2(0.1, 0);
            GL.Color3(Color.FromArgb(0, 0, 255));
            GL.Vertex2(0.1, 0.1);

            GL.End();

            this.SwapBuffers();
        }

    }
}