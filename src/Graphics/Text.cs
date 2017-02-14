using System.Collections.Generic;

namespace Snake.Graphics {
    public enum HorizontalTextAlignment {
        Left, Center, Right
    }

    public class Text : IPositionable {
        private List<string> lines = new List<string>();

        public Vector Position { get; set; }

        private Vector _Size;
        public Vector Size {
            get { return this._Size; }
            set {
                if (this._Size != value) {
                    this._Size = value;
                    this.RecalculateLayout();
                }
            }
        }

        private bool _Multiline = false;
        public bool Multiline {
            get { return this._Multiline; }
            set {
                if (this._Multiline != value) {
                    this._Multiline = value;
                    this.RecalculateLayout();
                }
            }
        }

        private HorizontalTextAlignment _HorizontalAlignment = HorizontalTextAlignment.Left;
        public HorizontalTextAlignment HorizontalAlignment {
            get { return this._HorizontalAlignment; }
            set {
                if (this._HorizontalAlignment != value) {
                    this._HorizontalAlignment = value;
                    this.RecalculateLayout();
                }
            }
        }

        private string _Content;
        public string Content {
            get { return this._Content; }
            set {
                if (this._Content != value) {
                    this._Content = value;
                    this.RecalculateLayout();
                }
            }
        }

        public Text(string content, Vector? size = null, Vector? pos = null, HorizontalTextAlignment horizontalAlignment = HorizontalTextAlignment.Left, bool multiline = false) {
            this._Content = content;
            this._HorizontalAlignment = horizontalAlignment;
            this._Multiline = multiline;

            this._Size = size ?? new Vector();
            this.Position = pos ?? new Vector();

            this.RecalculateLayout();
        }

        public void Update() { }

        public void Draw(Screen screen, Vector parentPos) {
            Vector pos = parentPos + this.Position;
            for (int i = 0; i < this.lines.Count; i++) {
                pos += new Vector(0, 1);
                screen.DrawString(pos, this.lines[i]);
            }
        }

        private void RecalculateLayout() {
            this.lines.Clear();

            if (this.Size.X == 0 || this.Size.Y == 0) return;

            if (!this.Multiline) {
                this.lines.Add(this.Content.Replace("\n", "").MaxLength(this.Size.X));
            } else {

            }

            for (int i = 0; i < this.lines.Count; i++) {
                switch (this.HorizontalAlignment) {
                    case HorizontalTextAlignment.Left:
                        this.lines[i] = this.lines[i].RightPad(' ', this.Size.X);
                        break;
                    case HorizontalTextAlignment.Right:
                        this.lines[i] = this.lines[i].LeftPad(' ', this.Size.X);
                        break;
                    case HorizontalTextAlignment.Center:
                        this.lines[i] = this.lines[i].Center(this.Size.X).MaxLength(this.Size.X);
                        break;
                }
            }

            while (this.lines.Count > this.Size.Y && this.lines.Count > 0) {
                this.lines.Pop();
            }
        }
    }
}
