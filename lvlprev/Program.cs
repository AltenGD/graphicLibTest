using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;

namespace Game1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1280, 720);
            game.Run();
        }
    }
}