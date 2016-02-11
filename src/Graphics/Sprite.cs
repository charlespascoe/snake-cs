using System;

namespace Snake.Graphics {
    public class Sprite : CellMatrix, IPositionable {
        private Vector _Position;
        public Vector Position {
            get { return this._Position; }
            set {
                if (value != null) {
                    this._Position = value;
                }
            }
        }

        public new Vector Size {
            get { return base.Size; }
            set {
                // Silently do nothing
            }
        }

        public Sprite(Vector position, Vector size) : base(size) {
            this.Position = position;
        }

        public void Update() {

        }

        public void Draw(Screen screen, Vector parentPos) {
            screen.SetCells(parentPos + this.Position, this.cells);
        }
    }
}

