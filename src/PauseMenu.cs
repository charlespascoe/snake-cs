using System;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class PauseMenu : Box, IFocusable  {
        private Layout layout;
        private Lense lense;

        public event BlurEventHander OnBlur;
        public event EventHandler OnResume;

        public bool IsFocussed { get; private set; }

        public PauseMenu(Vector position, Vector size) : base(position, size) {
            this.Style = new RoundedBoxStyle();

            this.lense = new Lense();

            Button resumeBtn = new Button("Resume");
            Button b2 = new Button("Test 2");
            Button quitBtn = new Button("Quit");

            resumeBtn.OnClick += (sender, e) => this.OnResume?.Invoke(this, EventArgs.Empty);
            quitBtn.OnClick += (sender, e) => Program.Quit();

            this.layout = new VerticalLayout(position: new Vector(1, 2), size: this.Size - new Vector(2, 2)).Children(
                resumeBtn,
                b2,
                quitBtn
            );

            this.lense.AddChild(resumeBtn);
            this.lense.AddChild(b2);
            this.lense.AddChild(quitBtn);

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
            this.lense.Focus();
        }

        public void Blur(BlurEventArgs e = null) {
            this.IsFocussed = false;
            this.lense.Blur();

            if (e != null && this.OnBlur != null) {
                this.OnBlur(this, e);
            }
        }
    }
}

