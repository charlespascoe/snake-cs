using System;
using System.Collections.Generic;
using Snake.Graphics;

namespace Snake.UI {
    public class VerticalLayout : IPositionable {
        private List<IPositionable> children = new List<IPositionable>();
        private LayoutSizing sizing;

        private Vector _Position = new Vector();
        public Vector Position {
            get { return _Position; }
            set {
                if (value != null && value != this._Position) {
                    this._Position = value;
                }
            }
        }

        private Vector _Size = new Vector();
        public Vector Size {
            get { return _Size; }
            set {
                if (value != null && value != this._Size) {
                    this._Size = value;
                    this.CalculateChildLayouts();
                }
            }
        }

        private int _Spacing = 0;
        public int Spacing {
            get { return _Spacing; }
            set {
                if (value >= 0 && value != _Spacing) {
                    this._Spacing = value;
                    this.CalculateChildLayouts();
                }
            }
        }

        public VerticalLayout(Vector position, Vector size, LayoutSizing sizing=LayoutSizing.Default) {
            this.Position = new Vector(position);
            this.Size = new Vector(size);
            this.sizing = sizing;
        }

        public void Update() {
            foreach (IPositionable child in this.children) {
                child.Update();
            }
        }

        public void Draw(Screen screen, Vector parentPos) {
            foreach (IPositionable child in this.children) {
                child.Draw(screen, parentPos + this.Position);
            }
        }

        public void AddChild(IPositionable child) {
            this.children.Add(child);
            this.CalculateChildLayouts();
        }

        private void CalculateChildLayouts() {
            int yPos = 0;
            foreach (IPositionable child in this.children) {
                switch (this.sizing) {
                    case LayoutSizing.Default:
                        child.Position = new Vector(0, yPos);
                        break;
                    case LayoutSizing.Stretch:
                        child.Size = new Vector(this.Size.X, child.Size.Y);
                        child.Position = new Vector(0, yPos);
                        break;
                    case LayoutSizing.Center:
                        child.Position = new Vector((this.Size.X - child.Size.X) / 2, yPos);
                        break;
                }

                yPos += child.Size.Y + this.Spacing;
            }
        }
    }
}

