using System;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class Game : Context {
        private GameArea gameArea;
        private ScoreBox scoreBox;

        public Game(Vector screenSize, DifficultySettings settings) : base(screenSize) {
            this.gameArea = new GameArea(new Vector(8, 4), screenSize - new Vector(16, 12), settings);
            this.gameArea.OnScoreChange += new EventHandler(this.OnScoreChange);

            Vector scoreBoxSize = new Vector(8, 3);
            Vector scoreBoxPosition = new Vector(
                (screenSize.X - scoreBoxSize.X) / 2,
                gameArea.Position.Y + gameArea.Size.Y + 2
            );

            this.scoreBox = new ScoreBox(scoreBoxPosition, scoreBoxSize);
        }

        public override void Update() {
            this.gameArea.Update();
            this.scoreBox.Update();
        }

        public override void Draw(Screen screen) {
            this.gameArea.Draw(screen, new Vector());
            this.scoreBox.Draw(screen, new Vector());
        }

        private void OnScoreChange(object sender, EventArgs e) {
            this.scoreBox.Score = this.gameArea.Score;
        }
    }
}

