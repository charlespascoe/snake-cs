using System;

namespace Snake.Graphics {
    public class Screen {
        public bool CursorVisible {
            get { return Console.CursorVisible; }
            set { Console.CursorVisible = value; }
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public ConsoleColor DefaultForeground { get; set; }
        public ConsoleColor DefaultBackground { get; set; }

        // Subtract 1, because when the cursor writes the last line,
        // it will go to the next line, pushing everything up by 1
        public Screen() : this(Console.WindowWidth, Console.WindowHeight - 1) {
        }

        private Cell[,] buffer;

        public Screen(int width, int height) {
            if (width < 0 || height < 0) {
                throw new ArgumentOutOfRangeException("width and height must be greater than 0");
            }

            this.buffer = new Cell[width, height];
            this.Width = width;
            this.Height = height;

            this.Clear();

            this.CursorVisible = false;

            this.DefaultForeground = ConsoleColor.White;
            this.DefaultBackground = ConsoleColor.Black;
        }

        public void Clear() {
            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    this.buffer[x, y] = new Cell(' ', this.DefaultForeground, this.DefaultBackground);
                }
            }
            Console.Clear();
        }

        public void SetCell(Vector v, char c) {
            this.SetCell(v.X, v.Y, c);
        }

        public void SetCell(int x, int y, char c) {
            if ((int)c > 0 && x >= 0 && y >= 0 && x < this.Width && y < this.Height) {
                this.buffer[x, y].Character = c;
            }
        }

        public void SetCell(Vector v, char c, ConsoleColor f, ConsoleColor b) {
            this.SetCell(v.X, v.Y, c, f, b);
        }

        public void SetCell(int x, int y, char c, ConsoleColor f, ConsoleColor b) {
            if ((int)c > 0 && x >= 0 && y >= 0 && x < this.Width && y < this.Height) {
                Cell cell = this.buffer[x, y];
                cell.Character = c;
                cell.Foreground = f;
                cell.Background = b;
            }
        }

        public int GetChangedCount() {
            int changed = 0;
            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    if (this.buffer[x, y].HasChanged) {
                        changed++;
                    }
                }
            }
            return changed;
        }

        public void DrawAll() {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = this.DefaultForeground;
            Console.BackgroundColor = this.DefaultBackground;

            char[] row = new char[this.Width];
            for (int y = 0; y < this.Height; y++) {
                for (int x = 0; x < this.Width; x++) {
                    Cell cell = this.buffer[x, y];

                    if (cell.Foreground == this.DefaultBackground && cell.Background == this.DefaultBackground) {
                        cell.AfterDraw();
                    }

                    row[x] = cell.Character;
                }
                Console.Write(row);
            }
        }

        public void Draw() {
            for (int y = 0; y < this.Height; y++) {
                for (int x = 0; x < this.Width; x++) {
                    Cell cell = this.buffer[x, y];
                    if (cell.HasChanged) {
                        Console.ForegroundColor = cell.Foreground;
                        Console.BackgroundColor = cell.Background;
                        Console.SetCursorPosition(x, y);
                        Console.Write(cell.Character);
                        cell.AfterDraw();
                    }
                }
            }
        }
    }
}
