using System;

namespace Snake.Graphics {
    public enum HorizontalPosition {
        Default, Left, Center, Right, Stretch
    }

    public enum VerticalPosition {
        Default, Top, Center, Bottom, Stretch
    }

    public class Container : IPositionable {
        private IPositionable child;


        private HorizontalPosition _Horizontal;
        public HorizontalPosition Horizontal {
            get { return this._Horizontal; }
            set {
                if (value != this._Horizontal) {
                    this._Horizontal = value;
                    this.CalculateChildLayout();
                }
            }
        }

        private VerticalPosition _Vertical;
        public VerticalPosition Vertical {
            get { return this._Vertical; }
            set {
                if (value != this._Vertical) {
                    this._Vertical = value;
                    this.CalculateChildLayout();
                }
            }
        }

        public Vector Position { get; set; }

        private Vector _Size;
        public Vector Size {
            get { return this._Size; }
            set {
                if (value != null && value != this._Size) {
                    this._Size = value;
                    this.CalculateChildLayout();
                }
            }
        }

        private Padding _ContainerPadding;
        public Padding ContainerPadding {
            get { return this._ContainerPadding; }
            set {
                if (value != null && value != this._ContainerPadding) {
                    this._ContainerPadding = value;
                    this.CalculateChildLayout();
                }
            }
        }

        public Container(IPositionable child)
            : this(child, HorizontalPosition.Default, VerticalPosition.Default) {}

        public Container(IPositionable child, HorizontalPosition horizontalPos, VerticalPosition verticalPos)
            : this(child, horizontalPos, verticalPos, new Padding(0, 0, 0, 0)) {}

        public Container(IPositionable child, HorizontalPosition horizontalPos, VerticalPosition verticalPos, Padding padding) {
            this.child = child;
            this._ContainerPadding = padding;
            this._Size = new Vector(
                this.child.Size.X  + this.ContainerPadding.Left + this.ContainerPadding.Right,
                this.child.Size.Y + this.ContainerPadding.Top + this.ContainerPadding.Bottom
            );
            this._Horizontal = horizontalPos;
            this._Vertical = verticalPos;
            this.CalculateChildLayout();
        }


        public void Update() {
            this.child.Update();
        }

        public void Draw(Screen screen, Vector parentPos) {
            this.child.Draw(screen, parentPos + this.Position);
        }

        private void CalculateChildLayout() {
            int x, y, width = this.child.Size.X, height = this.child.Size.Y;

            Vector innerSize = this.Size - new Vector(this.ContainerPadding.Left + this.ContainerPadding.Right, this.ContainerPadding.Top + this.ContainerPadding.Bottom);

            switch (this.Horizontal) {
                case HorizontalPosition.Left:
                    x = 0;
                    break;
                case HorizontalPosition.Center:
                    x = (innerSize.X - this.child.Size.X) / 2;
                    break;
                case HorizontalPosition.Right:
                    x = innerSize.X - this.child.Size.X;
                    break;
                case HorizontalPosition.Stretch:
                    x = 0;
                    width = innerSize.X;
                    break;
                default:
                    x = this.child.Position.X;
                    break;
            }

            switch (this.Vertical) {
                case VerticalPosition.Top:
                    y = 0;
                    break;
                case VerticalPosition.Center:
                    y = (innerSize.Y - this.child.Size.Y) / 2;
                    break;
                case VerticalPosition.Bottom:
                    y = innerSize.Y - this.child.Size.Y;
                    break;
                case VerticalPosition.Stretch:
                    y = 0;
                    height = innerSize.Y;
                    break;
                default:
                    y = this.child.Position.Y;
                    break;
            }

            this.child.Position = new Vector(x, y);
            this.child.Size = new Vector(width, height);
        }
    }
}

