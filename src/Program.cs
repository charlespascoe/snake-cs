using System;
using System.Threading;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class Program {
        private static Context currentContext;

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

            Program.currentContext = new MainMenu(new Vector(screen.Width, screen.Height));
            Program.currentContext.OnChangeContext += new ChangeContextEventHandler(Program.OnChangeContext);

            while (true) {
                DateTime start = DateTime.Now;
                UserInput.Update();
                Program.currentContext.Update();
                Program.currentContext.Draw(screen);

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

        private static void OnChangeContext(object sender, ChangeContextEventArgs e) {
            Program.currentContext = e.NewContext;
            Program.currentContext.Update();
            Program.currentContext.OnChangeContext += new ChangeContextEventHandler(Program.OnChangeContext);
        }
    }
}

