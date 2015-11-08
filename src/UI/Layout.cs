using System;
using System.Collections.Generic;
using Snake.Graphics;

namespace Snake.UI {
    public abstract class Layout : IPositionable {
        protected List<IPositionable> children = new List<IPositionable>();

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

        public Layout(Vector position, Vector size) {
            this.Position = position;
            this.Size = size;
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

        protected abstract void CalculateChildLayouts();
    }
}

