using System;
using Snake.Graphics;

namespace Snake {
    public class BodySegment : GameEntity {
        public override Vector GamePosition { get; set; }

        public char BodyCharRight { get; set; }
        public char BodyCharLeft { get; set; }
        public Colour Foreground { get; set; }
        public Colour Background { get; set; }

        public BodySegment() {
            this.BodyCharRight = ' ';
            this.BodyCharLeft = ' ';
            this.Foreground = Colour.White;
            this.Background = new Colour(0, 3, 0);
            this.GamePosition = new Vector();
        }

        public override void Update() {
        }

        public override void Draw(Screen screen, Vector parentPos) {
            Vector screenPosition = parentPos + new Vector(this.GamePosition.X * 2, this.GamePosition.Y);

            screen.SetCell(screenPosition, this.BodyCharLeft, this.Foreground, this.Background);
            screen.SetCell(screenPosition + new Vector(1, 0), this.BodyCharRight, this.Foreground, this.Background);
        }

        public void Dead() {
            this.Background = new Colour(5, 0, 1);
        }
    }
}

