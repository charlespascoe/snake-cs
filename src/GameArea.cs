using System;
using Snake.Graphics;
using System.Collections.Generic;

namespace Snake {
    public class GameArea : IDrawable {
        private Box background;
        private SnakeBody snake;
        private List<GameEntity> entities;

        public Vector Size {
            get { return background.Size; }
        }

        public Vector GameAreaSize { get; private set; }

        public Vector Position { get; private set; }

        public GameArea(int x, int y, int width, int height) {
            this.Position = new Vector(x, y);
            this.background = new Box(0, 0, width, height);
            this.background.HasBorder = true;
            this.background.Style = new DoubleLineBoxStyle();
            this.background.Style.BorderForeground = ConsoleColor.Blue;

            // Subtract 2 to take into account the border
            this.GameAreaSize = new Vector((this.Size.X - 2) / 2, this.Size.Y - 2);

            this.snake = new SnakeBody(5, this.GameAreaSize);
            this.snake.OnMove += new EventHandler(this.OnSnakeMove);

            this.entities = new List<GameEntity>();

            for (int i = 0; i < 5; i++) {
                this.AddFood();
            }
        }

        public void Update() {
            foreach (GameEntity entity in this.entities) {
                entity.Update();
            }

            this.snake.Update();
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
                        this.AddFood();
                        break;
                    }
                }
            }
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

