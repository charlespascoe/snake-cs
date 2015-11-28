using System;
using Snake.Graphics;

namespace Snake.UI {
    public class HorizontalLayout : Layout {
        private int _Spacing = 0;
        public int Spacing {
            get { return this._Spacing; }
            set {
                if (value >= 0 && value != this._Spacing) {
                    this._Spacing = value;
                    this.CalculateChildLayouts();
                }
            }
        }

        public HorizontalLayout(Vector position, Vector size) : base(position, size) {}

        protected override void CalculateChildLayouts() {
            int xPos = 0;
            foreach (IPositionable child in this.children) {
                child.Position = new Vector(xPos, 0);
                child.Size = new Vector(child.Size.X, this.Size.Y);
                xPos += child.Size.X + this.Spacing;
            }
        }
    }
}

