using System;
using Snake.Graphics;

namespace Snake {
    public class Food : GameEntity {
        public Food() : this(0, 0) {}

        public Food(Vector gamePosition) : this(gamePosition.X, gamePosition.Y) {}

        public Food(int x, int y) {
            this.GamePosition = new Vector(x, y);
        }

        public override void Update() {}

        public override void Draw(Screen screen, Vector parentPos) {
            Vector screenPos = parentPos + new Vector(this.GamePosition.X * 2, this.GamePosition.Y);
            screen.SetCell(screenPos, '[', Colour.Yellow, Colour.Black);
            screen.SetCell(screenPos + new Vector(1, 0), ']', Colour.Yellow, Colour.Black);
        }
    }
}

