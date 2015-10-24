using System;
using System.Threading;
using System.Collections.Generic;

namespace Snake {
    public class Program {
        public static void Main(string[] args) {
            SnakeBody s = new SnakeBody();
            Box b = new Box(30, 30, 10, 3);
            b.background = ConsoleColor.Blue;
            // b.borderBackground = ConsoleColor.DarkBlue;
            b.borderForeground = ConsoleColor.Yellow;

            Screen screen = new Screen();

            List<string> ts = new List<string>();

            for (int i = 0; i < 100; i++) {
                DateTime start = DateTime.Now;
                s.Draw(screen, new Vector(i, 0));
                b.Draw(screen, new Vector(0, 0));
                TimeSpan t1 = DateTime.Now - start;
                screen.Draw();
                TimeSpan t2 = DateTime.Now - start;

                ts.Add(t1.Milliseconds.ToString() + " " + t2.Milliseconds.ToString());

                int timeout = 50 - t2.Milliseconds;

                if (timeout < 0) timeout = 0;
                Thread.Sleep(timeout);
            }

            foreach (string t in ts) {
                Console.WriteLine(t);
            }
        }
    }
}

