using OpenTK;

namespace lvlprevew
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1280, 729, null, "Level Preview", GameWindowFlags.Fullscreen);

            double fps = 60;
            game.VSync = VSyncMode.Adaptive;

            game.Run(fps, fps);
        }
    }
}