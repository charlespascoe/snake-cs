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

        public int Score { get; set; }

        public bool Visible { get; set; }

        private int score;
        public GameOverPanel() : base(new Vector(), new Vector(64, 12)) {
            this.Style = new RoundedBoxStyle();
            this.Style.BorderForeground = Colour.Red;

            this.rootLayout = new VerticalLayout(new Vector(1, 1), this.Size - new Vector(2, 2));
            this.rootLayout.AddChild(new Container(this.gameOverSprite, horizontalPos: HorizontalPosition.Center));
        }

        public override void Draw(Screen screen, Vector parentPos) {
            if (!this.Visible) return;

            base.Draw(screen, parentPos);

            this.gameOverSprite.Draw(screen, parentPos + this.Position + new Vector(1, 1));

            string yourScore = $"Your Score: {this.Score}";

            screen.DrawString(parentPos + this.Position + new Vector((this.Size.X - yourScore.Length) / 2, this.Size.Y - 3), yourScore);
        }
    }
}
