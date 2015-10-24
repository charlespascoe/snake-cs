using System;

namespace Snake {
    public class Screen {
        public bool CursorVisible {
            get { return Console.CursorVisible; }
            set { Console.CursorVisible = value; }
        }

        public int Width {
            get { return Console.WindowWidth; }
        }

        public int Height {
            get { return Console.WindowHeight; }
        }

        public ConsoleColor Background {
            get { return Console.BackgroundColor; }
            set { Console.BackgroundColor = value; }
        }

        public ConsoleColor Foreground {
            get { return Console.ForegroundColor; }
            set { Console.ForegroundColor = value; }
        }

        public Screen() {
            this.CursorVisible = false;
            this.Clear();
        }

        public void Clear() {
            Console.Clear();
        }

        public void SetCell(Vector v, char c) {
            this.SetCell(v.X, v.Y, c);
        }

        public void SetCell(int x, int y, char c) {
            if ((int)c > 0 && x >= 0 && y >= 0 && x < this.Width && y < this.Width) {
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }
        }
    }
}

