using System;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class PauseMenu : Box, IFocusable  {
        private VerticalLayout layout;
        private Lense lense;

        public event BlurEventHander OnBlur;
        public event EventHandler OnResume;

        public bool IsFocussed { get; private set; }

        public PauseMenu(Vector position, Vector size) : base(position, size) {
            this.Style = new RoundedBoxStyle();

            this.lense = new Lense();

            this.layout = new VerticalLayout(new Vector(1, 2), new Vector(this.Size) - new Vector(2, 2));
            this.layout.Spacing = 0;

            Button b1 = new Button("Resume");
            Button b2 = new Button("Test 2");
            Button b3 = new Button("Test 3");

            b1.OnClick += new EventHandler(this.HandleB1Click);
            b2.OnClick += new EventHandler(this.HandleB2Click);

            this.layout.AddChild(b1);
            this.layout.AddChild(b2);
            this.layout.AddChild(b3);

            this.lense.AddChild(b1);
            this.lense.AddChild(b2);
            this.lense.AddChild(b3);

            this.lense.Focus();
        }

        public override void Update() {
            this.layout.Update();
        }

        public override void Draw(Screen screen, Vector parentPos) {
            if (!this.IsFocussed) return;

            base.Draw(screen, parentPos);
            screen.DrawString(parentPos + this.Position + new Vector(1, 1), "Paused".Center(this.Size.X - 2));
            this.layout.Draw(screen, parentPos + this.Position);
        }

        public void Focus() {
            this.IsFocussed = true;
        }

        public void Blur(BlurEventArgs e = null) {
            this.IsFocussed = false;

            if (e != null && this.OnBlur != null) {
                this.OnBlur(this, e);
            }
        }

        private void HandleB1Click(object sender, EventArgs e) {
            if (this.OnResume != null) {
                this.OnResume(this, EventArgs.Empty);
            }
        }

        private void HandleB2Click(object sender, EventArgs e) {
            Logger.Write("PauseMenu", "B2 Click!");
        }


    }
}

