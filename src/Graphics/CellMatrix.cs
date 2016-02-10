using System;

namespace Snake.Graphics {
    public abstract class CellMatrix {
        protected Cell[,] cells;

        public Vector Size { get; private set; }

        public CellMatrix(Vector size, char defaultChar, ConsoleColor defaultForeground, ConsoleColor defaultBackground) {
            this.Size = size;

            this.cells = new Cell[size.X, size.Y];

            for (int x = 0; x < size.X; x++) {
                for (int y = 0; y < size.Y; y++) {
                    this.cells[x, y] = new Cell(defaultChar, defaultForeground, defaultBackground);
                }
            }
        }

        public void SetCell(Vector position, char c, ConsoleColor? foreground = null, ConsoleColor? background = null) {
            if (position.X >= 0 && position.X < this.Size.X && position.Y >= 0 && position.Y < this.Size.Y) {
                Cell cell = this.cells[position.X, position.Y];

                cell.Character = c;

                if (foreground != null) {
                    cell.Foreground = (ConsoleColor)foreground;
                }

                if (background != null) {
                    cell.Background = (ConsoleColor)background;
                }
            }
        }

        public void SetCells(Vector position, Vector size, char c, ConsoleColor? foregound = null, ConsoleColor? background = null) {
            if ((int)c == 0) return;

            for (int x = 0; x < size.X; x++) {
                int i = x + position.X;

                if (i < 0 || i >= this.Size.X) continue;

                for (int y = 0; y < size.Y; y++) {
                    int j = y + position.Y;

                    if (j < 0 || j >= this.Size.Y) continue;

                    Cell cell = this.cells[i, j];
                    cell.Character = c;

                    if (foregound != null) {
                        cell.Foreground = (ConsoleColor)foregound;
                    }

                    if (background != null) {
                        cell.Background = (ConsoleColor)background;
                    }
                }
            }
        }

        protected void SetCells(Vector position, Cell[,] cells) {
            int cellsWidth = cells.GetLength(0);
            int cellsHeight = cells.GetLength(1);

            for (int x = 0; x < cellsWidth; x++) {
                int i = x + position.X;

                if (i < 0 || i >= this.Size.X) continue;

                for (int y = 0; y < cellsHeight; y++) {
                    int j = y + position.Y;

                    if (j < 0 || j >= this.Size.Y) continue;

                    Cell newCell = cells[x, y];

                    if ((int)newCell.Character == 0) continue;

                    Cell cell = this.cells[i, j];
                    cell.Character = newCell.Character;
                    cell.Background = newCell.Background;
                    cell.Foreground = newCell.Foreground;
                }
            }
        }

        public void DrawString(Vector position, String text) {
            foreach (char c in text) {
                this.SetCell(position, c);
                position += new Vector(1, 0);
            }
        }
    }
}

