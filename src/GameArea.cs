using System;
using Snake.Graphics;

namespace Snake {
    public class GameArea : IDrawable {
        private Box background;
        private SnakeBody snake;

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
        }

        public void Update() {
            this.snake.Update();
        }

        public void Draw(Screen screen, Vector parentPos) {
            this.background.Draw(screen, parentPos + this.Position);
            // Add Vector(1, 1) to take into account the border
            this.snake.Draw(screen, parentPos + new Vector(1, 1) + this.Position);
        }
    }
}

