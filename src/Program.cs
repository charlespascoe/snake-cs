using System;
using System.Threading;

namespace Snake {
    public class Program {
        public static void Main(string[] args) {
            SnakeBody s = new SnakeBody();

            Screen screen = new Screen();

            s.Draw(screen, new Vector(0, 0));
        }
    }
}

