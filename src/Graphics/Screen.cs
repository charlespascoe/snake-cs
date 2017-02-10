using System;
using System.IO;
using System.Collections.Generic;

namespace Snake.Graphics {
    public class Screen : CellMatrix {
        private const byte ESCAPE_BYTE = 27;

        private Stream stdout;

        public bool CursorVisible {
            get { return Console.CursorVisible; }
            set { Console.CursorVisible = value; }
        }

        private Colour currentForeground;
        private Colour currentBackground;

        // Subtract 1, because when the cursor writes the last line,
        // it will go to the next line, pushing everything up by 1
        public Screen() : base(new Vector(Console.WindowWidth, Console.WindowHeight - 1), ' ', Colour.White, Colour.Black) {
            this.CursorVisible = false;
            this.stdout = Console.OpenStandardOutput();
        }

        private int drawChangedThreshold = 1000;

        public int GetChangedCount() {
            int changed = 0;
            for (int x = 0; x < this.Size.X; x++) {
                for (int y = 0; y < this.Size.Y; y++) {
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

            this.SetForeground(this.cells[0, 0].Foreground);
            this.SetBackground(this.cells[0, 0].Background);

            for (int y = 0; y < this.Size.Y; y++) {
                for (int x = 0; x < this.Size.X; x++) {
                    Cell cell = this.cells[x, y];

                    if (cell.Foreground != this.currentForeground || cell.Background != this.currentBackground) {
                        Console.Write(writeBuffer.ToArray());
                        writeBuffer.Clear();

                        this.SetForeground(cell.Foreground);
                        this.SetBackground(cell.Background);
                    }

                    writeBuffer.Add(cell.Character);
                    cell.AfterDraw();
                }

                if (y < this.Size.Y - 1) {
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

            for (int y = 0; y < this.Size.Y; y++) {
                for (int x = 0; x < this.Size.X; x++) {
                    Cell cell = this.cells[x, y];
                    if (cell.HasChanged) {
                        this.SetForeground(cell.Foreground);
                        this.SetBackground(cell.Background);
                        Console.SetCursorPosition(x, y);
                        Console.Write(cell.Character);
                        cell.AfterDraw();
                    }
                }
            }
        }

        private void SetForeground(Colour col) {
            if (col == this.currentForeground) return;
            this.currentForeground = col;

            this.stdout.WriteByte(ESCAPE_BYTE);

            this.stdout.Write($"[38;5;{col.ToAnsiColourCode()}m");
        }

        private void SetBackground(Colour col) {
            if (col == this.currentBackground) return;
            this.currentBackground = col;

            this.stdout.WriteByte(ESCAPE_BYTE);

            this.stdout.Write($"[48;5;{col.ToAnsiColourCode()}m");
        }
    }
}

