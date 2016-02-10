using System;
using System.Collections.Generic;

namespace Snake.Graphics {
    public class Screen : CellMatrix {
        public bool CursorVisible {
            get { return Console.CursorVisible; }
            set { Console.CursorVisible = value; }
        }

        public int Width { get; private set; }

        public int Height { get; private set; }


        // Subtract 1, because when the cursor writes the last line,
        // it will go to the next line, pushing everything up by 1
        public Screen() : base(new Vector(Console.WindowWidth, Console.WindowHeight - 1), ' ', ConsoleColor.White, ConsoleColor.Black) { }

        private int drawChangedThreshold = 1000;

        public int GetChangedCount() {
            int changed = 0;
            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    if (this.cells[x, y].HasChanged) {
                        changed++;
                    }
                }
            }
            return changed;
        }

        public void DrawAll() {
            Console.Clear();

            List<char> writeBuffer = new List<char>();

            Console.ForegroundColor = this.cells[0, 0].Foreground;
            Console.BackgroundColor = this.cells[0, 0].Background;

            for (int y = 0; y < this.Height; y++) {
                for (int x = 0; x < this.Width; x++) {
                    Cell cell = this.cells[x, y];

                    if (cell.Foreground != Console.ForegroundColor || cell.Background != Console.BackgroundColor) {
                        Console.Write(writeBuffer.ToArray());
                        writeBuffer.Clear();

                        Console.ForegroundColor = cell.Foreground;
                        Console.BackgroundColor = cell.Background;
                    }

                    writeBuffer.Add(cell.Character);
                    cell.AfterDraw();
                }

                if (y < this.Height - 1) {
                    writeBuffer.Add('\n');
                }
            }

            Console.Write(writeBuffer.ToArray());
        }

        public void Draw() {
            if (this.GetChangedCount() > this.drawChangedThreshold) {
                this.DrawAll();
                return;
            }

            for (int y = 0; y < this.Height; y++) {
                for (int x = 0; x < this.Width; x++) {
                    Cell cell = this.cells[x, y];
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

