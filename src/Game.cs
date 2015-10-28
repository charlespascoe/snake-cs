using System;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class Game : Context {
        private List<IPositionable> layouts = new List<IPositionable>();
        private GameArea gameArea;
        private ScoreBox scoreBox;



        public Game(Vector screenSize, DifficultySettings settings) : base(screenSize) {
            VerticalLayout verticalLayout = new VerticalLayout(new Vector(8, 4), screenSize - new Vector(16, 8), LayoutSizing.Center);

            this.gameArea = new GameArea(new Vector(), verticalLayout.Size - new Vector(0, 5), settings);
            this.gameArea.OnScoreChange += new EventHandler(this.OnScoreChange);

            Vector scoreBoxSize = new Vector(8, 3);

            this.scoreBox = new ScoreBox(new Vector(), scoreBoxSize);

            verticalLayout.AddChild(gameArea);
            verticalLayout.AddChild(scoreBox);

            this.layouts.Add(verticalLayout);
        }

        public override void Update() {
            foreach (IPositionable layout in this.layouts) {
                layout.Update();
            }
        }

        public override void Draw(Screen screen) {
            foreach (IPositionable layout in this.layouts) {
                layout.Draw(screen, new Vector());
            }
        }

        private void OnScoreChange(object sender, EventArgs e) {
            this.scoreBox.Score = this.gameArea.Score;
        }
    }
}

