using System;

namespace Snake.Graphics {
    public class Box : IPositionable {
        public Vector Position { get; set; }
        public Vector Size { get; set; }

        public bool HasBorder { get; set; }

        public BoxStyle Style { get; set; }

        public Box() {

        }

        public Box(Vector position, Vector size) {
            Vector p = new Vector(position);
            Vector s = new Vector(size);

            if (s.X < 0) s.X = 0;
            if (s.Y < 0) s.Y = 0;

            this.Position = p;
            this.Size = s;
        }

        public virtual void Update() {}

        public virtual void Draw(Screen screen, Vector parentPos) {
            if (this.Style == null || this.Size.X <= 0 || this.Size.Y <= 0) return;

            screen.SetCells(parentPos + this.Position, this.Size, ' ', this.Style.Foreground, this.Style.Background);

            if (this.HasBorder) {
                for (int x = 0; x < this.Size.X; x++) {
                    screen.SetCell(
                        parentPos + this.Position + new Vector(x, 0),
                        this.GetBorderCell(x, 0),
                        this.Style.BorderForeground,
                        this.Style.BorderBackground
                    );

                    screen.SetCell(
                        parentPos + this.Position + new Vector(x, this.Size.Y - 1),
                        this.GetBorderCell(x, this.Size.Y - 1),
                        this.Style.BorderForeground,
                        this.Style.BorderBackground
                    );
                }

                for (int y = 1; y < this.Size.Y - 1; y++) {
                    screen.SetCell(
                        parentPos + this.Position + new Vector(0, y),
                        this.GetBorderCell(0, y),
                        this.Style.BorderForeground,
                        this.Style.BorderBackground
                    );

                    screen.SetCell(
                        parentPos + this.Position + new Vector(this.Size.X - 1, y),
                        this.GetBorderCell(this.Size.X - 1, y),
                        this.Style.BorderForeground,
                        this.Style.BorderBackground
                    );
                }
            }
        }

        private bool IsBorder(int x, int y) {
            return x == 0 || y == 0 || x == this.Size.X - 1 || y == this.Size.Y - 1;
        }

        private char GetBorderCell(int x, int y) {
            if (this.Style == null) return ' ';

            if (x == 0) {
                if (y == 0) {
                    return this.Style.TopLeftCorner;
                } else if (y == this.Size.Y - 1) {
                    return this.Style.BottomLeftCorner;
                }
            } else if (x == this.Size.X - 1) {
                if (y == 0) {
                    return this.Style.TopRightCorner;
                } else if (y == this.Size.Y - 1) {
                    return this.Style.BottomRightCorner;
                }
            }

            if (y == 0 || y == this.Size.Y - 1) {
                return this.Style.HorizontalBar;
            }

            if (x == 0 || x == this.Size.X - 1) {
                return this.Style.VerticalBar;
            }

            return (char)0;
        }
    }
}

