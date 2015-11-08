using System;
using System.Collections.Generic;
using Snake.Graphics;

namespace Snake.UI {
    public class VerticalLayout : Layout {

        public VerticalLayout(Vector position, Vector size) : base(position, size) {}

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

        protected override void CalculateChildLayouts() {
            int yPos = 0;
            foreach (IPositionable child in this.children) {
                child.Position = new Vector(0, yPos);
                child.Size = new Vector(this.Size.X, child.Size.Y);
                yPos += child.Size.Y + this.Spacing;
            }
        }
    }
}

