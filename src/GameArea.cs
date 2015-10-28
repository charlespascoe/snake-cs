using System;
using Snake.Graphics;
using System.Collections.Generic;

namespace Snake {
    public class GameArea : IPositionable {
        private Box background;
        private SnakeBody snake;
        private List<GameEntity> entities;
        private bool gameOver = false;
        private DifficultySettings settings;

        public Vector Size { get; set; }
        public Vector GameAreaSize { get; private set; }
        public Vector Position { get; set; }
        public int Score { get; private set; }

        public event EventHandler OnScoreChange;

        public GameArea(Vector position, Vector size, DifficultySettings settings) : this(position.X, position.Y, size.X, size.Y, settings) {}

        public GameArea(int x, int y, int width, int height, DifficultySettings settings) {
            this.Position = new Vector(x, y);
            this.Size = new Vector(width, height);
            this.background = new Box(0, 0, width, height);
            this.background.HasBorder = true;
            this.background.Style = new DoubleLineBoxStyle();
            this.background.Style.BorderForeground = ConsoleColor.Blue;

            this.settings = settings;

            // Subtract 2 to take into account the border
            this.GameAreaSize = new Vector((this.background.Size.X - 2) / 2, this.background.Size.Y - 2);

            this.snake = new SnakeBody(this.settings.StartSpeed, this.GameAreaSize);
            this.snake.OnMove += new EventHandler(this.OnSnakeMove);
            this.snake.OnDeath += new EventHandler(this.OnSnakeDeath);

            this.entities = new List<GameEntity>();

            for (int i = 0; i < this.settings.FoodCount; i++) {
                this.AddFood();
            }
        }

        public void Update() {
            foreach (GameEntity entity in this.entities) {
                entity.Update();
            }

            if (!this.gameOver) {
                this.snake.Update();
            }
        }

        public void Draw(Screen screen, Vector parentPos) {
            this.background.Draw(screen, parentPos + this.Position);

            foreach (GameEntity entity in this.entities) {
                entity.Draw(screen, parentPos + new Vector(1, 1) + this.Position);
            }

            // Add Vector(1, 1) to take into account the border
            this.snake.Draw(screen, parentPos + new Vector(1, 1) + this.Position);
        }

        private void OnSnakeMove(object sender, EventArgs e) {
            foreach (GameEntity entity in this.entities) {
                if (entity.GamePosition == this.snake.HeadPosition) {
                    if (entity is Food) {
                        this.entities.Remove(entity);
                        this.snake.Eat();
                        this.Score++;
                        if (this.Score % this.settings.PointsBetweenSpeedup == 0) {
                            this.snake.SpeedUp();
                        }
                        this.AddFood();

                        if (this.OnScoreChange != null) this.OnScoreChange(this, EventArgs.Empty);

                        break;
                    }
                }
            }
        }

        private void OnSnakeDeath(object sender, EventArgs e) {
            this.gameOver = true;
        }

        private bool CollidesWithEntity(Vector gamePosition) {
            foreach (GameEntity entity in this.entities) {
                if (entity.GamePosition == gamePosition) {
                    return true;
                }
            }

            return false;
        }

        private void AddFood() {
            Vector foodPos;
            Random r = new Random();

            do {
                foodPos = new Vector(r.Next(0, this.GameAreaSize.X), r.Next(0, this.GameAreaSize.Y));
            } while (this.snake.CollidesWithBody(foodPos) || this.CollidesWithEntity(foodPos));

            this.entities.Add(new Food(foodPos));
        }
    }
}

