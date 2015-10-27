using System;
using System.Threading;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class Program {
        public static void Main(string[] args) {
            Logger.Instance = new Logger("log.txt");

            try {
                Program.RunGame();
            } catch (Exception ex) {
                Logger.Instance.Write("Error", ex.ToString());
            } finally {
                Logger.Instance.Flush();
                Logger.Instance.Close();
            }
        }

        public static void RunGame() {

            Box b = new Box(30, 45, 20, 3);
            b.Style = new RoundedBoxStyle();
            b.HasBorder = true;
            b.Style.Background = ConsoleColor.Blue;
            b.Style.BorderForeground = ConsoleColor.Yellow;

            GameArea g = new GameArea(8, 8, 64, 32);

            Button button = new Button(50, 45, 20, 3, "Test");
            button.Style = new RoundedBoxStyle();
            button.HasBorder = true;
            button.Style.BorderForeground = ConsoleColor.Yellow;
            button.IsFocussed = true;


            Screen screen = new Screen();
            screen.DefaultForeground = ConsoleColor.White;
            screen.DefaultBackground = ConsoleColor.Black;

            for (int i = 0; i < 1000; i++) {
                DateTime start = DateTime.Now;
                UserInput.Update();
                g.Update();

                g.Draw(screen, new Vector());
                b.Draw(screen, new Vector());
                button.Draw(screen, new Vector());

                if (UserInput.KeyPressed) {
                    screen.SetCell(0, 0, UserInput.KeyChar, ConsoleColor.White, ConsoleColor.Blue);
                    screen.SetCell(2, 0, (int)UserInput.KeyChar == 0 ? '0' : ' ', ConsoleColor.White, ConsoleColor.Blue);
                    screen.SetCell(1, 0, UserInput.Key == ConsoleKey.Enter ? '#' : ' ', ConsoleColor.White, ConsoleColor.Black);
                } else {
                    screen.SetCell(0, 0, UserInput.KeyChar, ConsoleColor.White, ConsoleColor.Black);
                }

                TimeSpan t1 = DateTime.Now - start;
                screen.Draw();
                TimeSpan t2 = DateTime.Now - start;

                Logger.Instance.Write("Performance", t1.Milliseconds.ToString() + " " + t2.Milliseconds.ToString());


                int timeout = 25 - t2.Milliseconds;

                if (timeout < 0) timeout = 0;
                Thread.Sleep(timeout);
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 1);

            screen.CursorVisible = true;


        }
    }
}

