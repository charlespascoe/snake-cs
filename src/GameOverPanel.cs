using System;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class GameOverPanel : Box {
        private readonly Sprite gameOverSprite = Sprite.FromStringArray(new string[] {
         @"    _________    __  _________   ____ _    ____________ ",
         @"   / ____/   |  /  |/  / ____/  / __ \ |  / / ____/ __ \",
         @"  / / __/ /| | / /|_/ / __/    / / / / | / / __/ / /_/ /",
         @" / /_/ / ___ |/ /  / / /___   / /_/ /| |/ / /___/ _, _/ ",
         @" \____/_/  |_/_/  /_/_____/   \____/ |___/_____/_/ |_|  "
        }, Colour.Yellow, Colour.Black);

        private VerticalLayout rootLayout;

        private Text scoreText;

        private Lense lense = new Lense();

        private int _Score;
        public int Score {
            get { return this._Score; }
            set {
                this._Score = value;
                this.scoreText.Content = $"Your Score: {value}";
            }
        }

        public event EventHandler OnRestart;

        public bool Visible { get; set; }

        public GameOverPanel() : base(new Vector(), new Vector(64, 15)) {
            this.Style = new RoundedBoxStyle();
            this.Style.BorderForeground = Colour.Red;

            this.scoreText = new Text("Your Score:", new Vector(0, 1), horizontalAlignment: HorizontalTextAlignment.Center);

            this.rootLayout = new VerticalLayout(new Vector(2, 1), this.Size - new Vector(4, 2));
            this.rootLayout.Spacing = 2;
            this.rootLayout.AddChild(new Container(this.gameOverSprite, horizontalPos: HorizontalPosition.Center));
            this.rootLayout.AddChild(this.scoreText);

            HorizontalLayout horizontalLayout = new HorizontalLayout(new Vector(), new Vector(0, 3));
            horizontalLayout.Spacing = 2;

            Button restartBtn = new Button("Restart");
            restartBtn.Size = new Vector((this.rootLayout.Size.X / 2) - 1, 3);
            restartBtn.OnClick += (sender, e) => this.OnRestart?.Invoke(this, EventArgs.Empty);

            Button quitBtn = new Button("Quit");
            quitBtn.Size = new Vector((this.rootLayout.Size.X / 2) - 1, 3);
            quitBtn.OnClick += (sender, e) => Program.Quit();

            horizontalLayout.AddChild(restartBtn);
            horizontalLayout.AddChild(quitBtn);

            this.rootLayout.AddChild(horizontalLayout);

            this.lense.AddChild(restartBtn);
            this.lense.AddChild(quitBtn);

            this.lense.Focus();
        }

        public override void Update() {
            base.Update();
            this.rootLayout.Update();
        }

        public override void Draw(Screen screen, Vector parentPos) {
            if (!this.Visible) return;

            base.Draw(screen, parentPos);

            this.rootLayout.Draw(screen, parentPos + this.Position);
        }
    }
}
