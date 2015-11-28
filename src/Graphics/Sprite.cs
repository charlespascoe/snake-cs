using System;

namespace Snake.Graphics {
    public class Sprite : IPositionable {
        private Cell[,] cells;

        private Vector _Position;
        public Vector Position {
            get { return this._Position; }
            set {
                if (value != null) {
                    this._Position = value;
                }
            }
        }

        private Vector _Size;
        public Vector Size {
            get { return this._Size; }
            set {
                // Silently do nothing
            }
        }

        public Sprite(Vector position, Vector size) {
            this._Size = size;
            this.Position = position;

            this.cells = new Cell[size.X, size.Y];

            for (int x = 0; x < size.X; x++) {
                for (int y = 0; y < size.Y; y++) {
                    this.cells[x, y] = new Cell((char)0, ConsoleColor.White, ConsoleColor.Black);
                }
            }
        }

        public void Update() {

        }

        public void Draw(Screen screen, Vector parentPos) {

        }

    }
}

