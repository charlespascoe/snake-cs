using System;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class Game : Context {
        private List<IPositionable> layouts = new List<IPositionable>();
        private GameArea gameArea;
        private ScoreBox scoreBox;
        private PauseMenu pauseMenu;

        public Game(Vector screenSize, DifficultySettings settings) : base(screenSize) {
            VerticalLayout verticalLayout = new VerticalLayout(new Vector(8, 4), screenSize - new Vector(16, 8));

            Vector scoreBoxSize = new Vector(8, 3);

            this.gameArea = new GameArea(new Vector(), verticalLayout.Size - new Vector(0, 5), settings);
            this.gameArea.OnScoreChange += this.OnScoreChange;

            this.scoreBox = new ScoreBox(new Vector(), scoreBoxSize);

            verticalLayout.AddChild(gameArea);
            verticalLayout.AddChild(new Container(scoreBox, horizontalPos: HorizontalPosition.Center, verticalPos: VerticalPosition.Center));

            this.layouts.Add(verticalLayout);

            Vector pauseMenuSize = new Vector(16, 12);
            Vector pauseMenuPos = verticalLayout.Position + this.gameArea.Position + (this.gameArea.Size - pauseMenuSize) / 2;
            this.pauseMenu = new PauseMenu(pauseMenuPos, pauseMenuSize);
            this.pauseMenu.OnResume += this.OnResume;
        }

        public override void Update() {
            if (!this.gameArea.Paused  && !UserInput.InputHandled && UserInput.Key == ConsoleKey.Escape) {
                this.gameArea.Paused = true;
                UserInput.InputHandled = true;
                this.pauseMenu.Focus();
            }

            foreach (IPositionable layout in this.layouts) {
                layout.Update();
            }

            this.pauseMenu.Update();
        }

        public override void Draw(Screen screen) {
            foreach (IPositionable layout in this.layouts) {
                layout.Draw(screen, new Vector());
            }

            this.pauseMenu.Draw(screen, new Vector());
        }

        private void OnScoreChange(object sender, EventArgs e) {
            this.scoreBox.Score = this.gameArea.Score;
        }

        private void OnResume(object sender, EventArgs e) {
            this.gameArea.Paused = false;
            this.pauseMenu.Blur();
        }
    }
}

