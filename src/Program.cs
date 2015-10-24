using System;
using System.Threading;

namespace Snake {
    public class Program {
        public static void Main(string[] args) {
            SnakeBody s = new SnakeBody();

            Screen screen = new Screen();

            for (int i = 0; i < 10; i++) {
                screen.Clear();
                s.Draw(screen, new Vector(i, 0));
                screen.Draw();
                Thread.Sleep(500);
            }

            Thread.Sleep(5000);
        }
    }
}

