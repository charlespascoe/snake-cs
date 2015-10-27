using System;
using Snake.Graphics;

namespace Snake {
    public class ScoreBox : Box {
        public int Score { get; set; }

        public ScoreBox(Vector position, Vector size) : this(position.X, position.Y, size.X, size.Y) {}

        public ScoreBox(int x, int y, int width, int height) : base(x, y, width, height) {
            this.Score = 0;
            this.HasBorder = true;
            this.Style = new RoundedBoxStyle();
        }

        public override void Draw(Screen screen, Vector parentPos) {
            base.Draw(screen, parentPos);

            screen.WriteString(parentPos + this.Position + new Vector(1, 1), this.Score.ToString().LeftPad('0', 2).Center(this.Size.X - 2));
        }
    }
}

