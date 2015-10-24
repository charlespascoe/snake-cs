using System;
using System.Threading;
using System.Collections.Generic;
using Snake.Graphics;

namespace Snake {
    public class Program {
        public static void Main(string[] args) {
            SnakeBody s = new SnakeBody();
            Box b = new Box(30, 30, 20, 3);
            b.Style = new RoundedBoxStyle();
            b.HasBorder = true;
            b.Style.Background = ConsoleColor.Blue;
            // b.borderBackground = ConsoleColor.DarkBlue;
            b.Style.BorderForeground = ConsoleColor.Yellow;


            Button button = new Button(50, 30, 20, 3, "Test");
            button.Style = new RoundedBoxStyle();
            button.HasBorder = true;
            button.Style.BorderForeground = ConsoleColor.Yellow;
            button.IsFocussed = true;


            Screen screen = new Screen();

            List<string> ts = new List<string>();

            for (int i = 0; i < 100; i++) {
                DateTime start = DateTime.Now;
                s.Draw(screen, new Vector(i, 0));
                b.Draw(screen, new Vector(0, 0));
                button.Draw(screen, new Vector());
                TimeSpan t1 = DateTime.Now - start;
                if (screen.GetChangedCount() > 500) {
                    Console.SetCursorPosition(1, 0);
                    screen.DrawAll();
                }
                screen.Draw();
                TimeSpan t2 = DateTime.Now - start;

                ts.Add(t1.Milliseconds.ToString() + " " + t2.Milliseconds.ToString());

                int timeout = 50 - t2.Milliseconds;

                if (timeout < 0) timeout = 0;
                Thread.Sleep(timeout);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);

            foreach (string t in ts) {
                Console.WriteLine(t);
            }
        }
    }
}

