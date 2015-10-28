using System;
using System.Threading;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class Program {
        public static void Main(string[] args) {
            Logger.Instance = new Logger("log.txt");

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Program.OnQuit);

            try {
                Program.RunGame();
            } catch (Exception ex) {
                Logger.Write("Error", ex.ToString());
            } finally {
                Program.OnQuit(null, null);
            }

        }

        private static void OnQuit(object sender, ConsoleCancelEventArgs e) {
                Console.CursorVisible = true;
                Console.Clear();
                Logger.Flush();
                Logger.Close();
        }

        public static void RunGame() {
            Screen screen = new Screen();
            screen.DefaultForeground = ConsoleColor.White;
            screen.DefaultBackground = ConsoleColor.Black;

            Game g = new Game(new Vector(screen.Width, screen.Height), new DifficultySettings(5, 10, 50));

            while (true) {
                DateTime start = DateTime.Now;
                UserInput.Update();
                g.Update();
                g.Draw(screen);

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

                //Logger.Instance.Write("Performance", t1.Milliseconds.ToString() + " " + t2.Milliseconds.ToString());

                int timeout = 25 - t2.Milliseconds;

                if (timeout < 0) timeout = 0;
                Thread.Sleep(timeout);
            }
        }
    }
}

