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
        private int ticksUntilNextFlash;

        public Vector Size { get; set; }
        public Vector GameAreaSize { get; private set; }
        public Vector Position { get; set; }
        public int Score { get; private set; }
        public bool Paused { get; set; }
        public bool FlashBorder { get; set; }

        public event EventHandler OnScoreChange;

        public event EventHandler OnDeath;

        public GameArea(Vector position, Vector size, DifficultySettings settings) {
            this.Position = new Vector(position);
            this.Size = new Vector(size);

            this.background = new Box(new Vector(), this.Size);
            this.background.Style = new DoubleLineBoxStyle();
            this.background.Style.BorderForeground = Colour.Blue;

            this.settings = settings;

            // Subtract 2 to take into account the border
            this.GameAreaSize = new Vector((this.background.Size.X - 2) / 2, this.background.Size.Y - 2);

            this.snake = new SnakeBody(this.settings.StartSpeed, this.GameAreaSize);
            this.snake.OnMove += this.OnSnakeMove;
            this.snake.OnDeath += this.OnSnakeDeath;

            this.entities = new List<GameEntity>();

            for (int i = 0; i < this.settings.FoodCount; i++) {
                this.AddFood();
            }

            this.Paused = false;
        }

        public void Update() {
            if (this.Paused) return;

            foreach (GameEntity entity in this.entities) {
                entity.Update();
            }

            if (this.FlashBorder) {
                this.ticksUntilNextFlash--;

                if (this.ticksUntilNextFlash <= 0) {
                    this.ticksUntilNextFlash = 10;

                    if (this.background.Style.BorderForeground != Colour.Red) {
                        this.background.Style.BorderForeground = Colour.Red;
                    } else {
                        this.background.Style.BorderForeground = Colour.White;
                    }
                }
            } else {
                this.background.Style.BorderForeground = Colour.Blue;
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
            this.FlashBorder = true;

            this.OnDeath?.Invoke(this, EventArgs.Empty);
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

