using System;

namespace Snake {
    public class Box : IDrawable {
        public Vector position;
        public Vector size;

        public bool HasBorder { get; set; }

        public ConsoleColor background;
        public ConsoleColor borderBackground;
        public ConsoleColor borderForeground;

        public BoxStyle Style { get; set; }

        public Box() {

        }

        public Box(int x, int y, int width, int height) {
            if (width < 0) width = 0;
            if (height < 0) height = 0;

            this.position = new Vector(x, y);
            this.size = new Vector(width, height);
        }

        public virtual void Update() {}

        public virtual void Draw(Screen screen, Vector parentPos) {
            if (this.size.X <= 0 || this.size.Y <= 0) return;

            for (int x = 0; x < this.size.X; x++) {
                for (int y = 0; y < this.size.Y; y++) {
                    char cell = ' ';
                    ConsoleColor b = this.background;
                    ConsoleColor f = this.background;
                    if (this.HasBorder && this.IsBorder(x, y)) {
                        cell = this.GetBorderCell(x, y);
                        b = borderBackground;
                        f = borderForeground;
                    }
                    screen.SetCell(parentPos + this.position + new Vector(x, y), cell, f, b);
                }
            }
        }

        private bool IsBorder(int x, int y) {
            return x == 0 || y == 0 || x == this.size.X - 1 || y == this.size.Y - 1;
        }

        private char GetBorderCell(int x, int y) {
            if (this.Style == null) return ' ';

            if (x == 0) {
                if (y == 0) {
                    return this.Style.TopLeftCorner;
                } else if (y == this.size.Y - 1) {
                    return this.Style.BottomLeftCorner;
                }
            } else if (x == this.size.X - 1) {
                if (y == 0) {
                    return this.Style.TopRightCorner;
                } else if (y == this.size.Y - 1) {
                    return this.Style.BottomRightCorner;
                }
            }

            if (y == 0 || y == this.size.Y - 1) {
                return this.Style.HorizontalBar;
            }

            if (x == 0 || x == this.size.X - 1) {
                return this.Style.VerticalBar;
            }

            return (char)0;
        }
    }
}

