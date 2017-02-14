using System;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class Game : Context {
        private Vector screenSize;
        private DifficultySettings settings;
        private List<IPositionable> layouts = new List<IPositionable>();
        private GameArea gameArea;
        private ScoreBox scoreBox;
        private PauseMenu pauseMenu;
        private bool gameOver;
        private int ticksUntilGameEnded = 100;
        private GameOverPanel gameOverPanel;

        public Game(Vector screenSize, DifficultySettings settings) : base(screenSize) {
            this.screenSize = screenSize;
            this.settings = settings;
            VerticalLayout verticalLayout = new VerticalLayout(new Vector(8, 4), screenSize - new Vector(16, 8));

            Vector scoreBoxSize = new Vector(8, 3);

            StackLayout stackLayout = new StackLayout(new Vector(), verticalLayout.Size - new Vector(0, scoreBoxSize.Y + 2));

            // Game Area
            this.gameArea = new GameArea(new Vector(), stackLayout.Size, settings);
            this.gameArea.OnScoreChange += this.OnScoreChange;
            this.gameArea.OnDeath += this.OnDeath;
            stackLayout.AddChild(this.gameArea);

            // Pause Menu
            this.pauseMenu = new PauseMenu(new Vector(), new Vector(16, 12));
            this.pauseMenu.OnResume += this.OnResume;
            this.pauseMenu.OnRestart += (sender, e) => this.Restart();
            stackLayout.AddChild(new Container(this.pauseMenu, horizontalPos: HorizontalPosition.Center, verticalPos: VerticalPosition.Center));

            // Game Over
            this.gameOverPanel = new GameOverPanel();
            this.gameOverPanel.OnRestart += (sender, e) => this.Restart();
            stackLayout.AddChild(new Container(this.gameOverPanel, horizontalPos: HorizontalPosition.Center, verticalPos: VerticalPosition.Center));

            verticalLayout.AddChild(stackLayout);

            // Score box
            this.scoreBox = new ScoreBox(new Vector(), scoreBoxSize);
            verticalLayout.AddChild(new Container(scoreBox, horizontalPos: HorizontalPosition.Center, verticalPos: VerticalPosition.Center));

            this.layouts.Add(verticalLayout);
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

            if (this.gameOver) {
                this.ticksUntilGameEnded--;

                if (this.ticksUntilGameEnded == 0) {
                    this.gameArea.FlashBorder = false;
                    this.gameOverPanel.Score = this.scoreBox.Score;
                    this.gameOverPanel.Visible = true;
                }
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

        private void OnDeath(object sender, EventArgs e) {
            this.gameOver = true;
        }

        private void Restart() {
            this.FireChangeContext(new ChangeContextEventArgs(new Game(this.screenSize, this.settings)));
        }

        private void OnResume(object sender, EventArgs e) {
            this.gameArea.Paused = false;
            this.pauseMenu.Blur();
        }
    }
}

