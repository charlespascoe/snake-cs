using System;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class Button : Box, IFocusable {
        public string Text { get; set; }

        public bool IsFocussed { get; private set; }

        public event OnBlurEventHander OnBlur;
        public event EventHandler OnClick;


        public Button() : base() {}

        public Button(string text) : this(new Vector(), new Vector(text.Length + 4, 3), text) {}

        public Button(Vector position, Vector size, string text) : base(position, size) {
            this.Text = text;
            this.Style = new RoundedBoxStyle();
        }

        public override void Update() {
            if (this.IsFocussed && UserInput.KeyPressed && !UserInput.InputHandled) {
                switch (UserInput.Key) {
                    case ConsoleKey.Tab:
                        Logger.Write("Button", "Focus next element!");
                        UserInput.InputHandled = true;
                        this.Blur(new OnBlurEventArgs(UserInput.ShiftPressed ? FocusDirection.Backward : FocusDirection.Forward));
                        break;
                    case ConsoleKey.Enter:
                        if (this.OnClick != null) {
                            this.OnClick(this, EventArgs.Empty);
                        }
                        UserInput.InputHandled = true;
                        break;
                }
            }
        }

        public void Focus() {
            this.IsFocussed = true;
        }

        public void Blur(OnBlurEventArgs e = null) {
            this.IsFocussed = false;

            if (e != null && this.OnBlur != null) {
                this.OnBlur(this, e);
            }
        }

        public override void Draw(Screen screen, Vector parentPos) {
            base.Draw(screen, parentPos);

            int maxTextLength = this.Size.X - 2;

            Vector textPosition = new Vector();

            if (this.Style != null && this.Style.HasBorder) {
                maxTextLength -= 2;
                textPosition.X++;
                textPosition.Y++;
            }

            string visibleText = this.Text.MaxLength(maxTextLength).Center(maxTextLength);

            if (this.IsFocussed) {
                visibleText = '*' + visibleText + '*';
            } else {
                visibleText = ' ' + visibleText + ' ';
            }

            screen.WriteString(parentPos + this.Position + textPosition, visibleText);
        }
    }
}

