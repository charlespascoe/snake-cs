using System;

namespace Snake.Graphics {
    public abstract class CellMatrix {
        protected Cell[,] cells;

        public Vector Size { get; private set; }

        public char DefaultChar { get; set; }
        public Colour DefaultForeground { get; set; }
        public Colour DefaultBackground { get; set; }

        public CellMatrix(Vector size) : this(size, (char)0, Colour.White, Colour.Black) { }

        public CellMatrix(Vector size, char defaultChar, Colour defaultForeground, Colour defaultBackground) {
            this.DefaultChar = defaultChar;
            this.DefaultForeground = defaultForeground;
            this.DefaultBackground = defaultBackground;

            this.Size = size;

            this.cells = new Cell[size.X, size.Y];

            this.Clear();
        }

        public void Clear() {
            for (int x = 0; x < this.Size.X; x++) {
                for (int y = 0; y < this.Size.Y; y++) {
                    this.cells[x, y] = new Cell(this.DefaultChar, this.DefaultForeground, this.DefaultBackground);
                }
            }
        }

        public void SetCell(Vector position, char c, Colour? foreground = null, Colour? background = null) {
            if (position.X >= 0 && position.X < this.Size.X && position.Y >= 0 && position.Y < this.Size.Y) {
                Cell cell = this.cells[position.X, position.Y];

                cell.Character = c;

                if (foreground != null) {
                    cell.Foreground = (Colour)foreground;
                }

                if (background != null) {
                    cell.Background = (Colour)background;
                }
            }
        }

        public void SetCells(Vector position, Vector size, char c, Colour? foregound = null, Colour? background = null) {
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
                        cell.Foreground = (Colour)foregound;
                    }

                    if (background != null) {
                        cell.Background = (Colour)background;
                    }
                }
            }
        }

        public void SetCells(Vector position, Cell[,] cells) {
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

