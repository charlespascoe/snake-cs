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

            Console.CancelKeyPress += (sender, e) => Program.Quit();

            try {
                Program.RunGame();
            } catch (Exception ex) {
                Logger.Write("Error", ex.ToString());
            } finally {
                Program.Quit(1);
            }
        }


        public static void RunGame() {
            Screen screen = new Screen();

            Program.currentContext = new MainMenu(screen.Size);
            Program.currentContext.OnChangeContext += Program.OnChangeContext;

            while (true) {
                DateTime start = DateTime.Now;
                UserInput.Update();
                Program.currentContext.Update();
                Program.currentContext.Draw(screen);

                TimeSpan t1 = DateTime.Now - start;
                screen.Draw();
                TimeSpan t2 = DateTime.Now - start;

                //Logger.Instance.Write("Performance", t1.Milliseconds.ToString() + " " + t2.Milliseconds.ToString());

                int timeout = 25 - t2.Milliseconds;

                if (timeout > 0) {
                    Thread.Sleep(timeout);
                }
            }
        }

        private static void OnChangeContext(object sender, ChangeContextEventArgs e) {
            Program.currentContext.OnChangeContext -= Program.OnChangeContext;
            Program.currentContext = e.NewContext;
            Program.currentContext.Update();
            Program.currentContext.OnChangeContext += Program.OnChangeContext;
        }

        public static void Quit(int exitCode = 0) {
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Logger.Flush();
            Logger.Close();
            Environment.Exit(exitCode);
        }
    }
}

