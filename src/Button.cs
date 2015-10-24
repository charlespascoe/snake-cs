using System;
using Snake.Graphics;

namespace Snake {
    public class Button : Box {
        public string Text { get; set; }

        public bool IsFocussed { get; set; }

        public Button() : base() {}

        public Button(int x, int y, int width, int height, string text) : base(x, y, width, height) {
            this.Text = text;
        }

        public override void Update() {

        }

        public override void Draw(Screen screen, Vector parentPos) {
            base.Draw(screen, parentPos);

            int maxTextLength = this.Size.X - 2;

            Vector textPosition = new Vector();

            if (this.HasBorder) {
                maxTextLength -= 2;
                textPosition.X++;
                textPosition.Y++;
            }

            string visibleText = Utils.CenterString(this.Text, maxTextLength);

            if (this.IsFocussed) {
                visibleText = '*' + visibleText + '*';
            } else {
                visibleText = ' ' + visibleText + ' ';
            }

            foreach (char c in visibleText) {
                screen.SetCell(parentPos + this.Position + textPosition, c);
                textPosition.X++;
            }
        }
    }
}

