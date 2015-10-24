using System;

namespace Snake {
    public class BodySegment : IDrawable {
        public Vector position = new Vector(0, 0);

        public char BodyChar { get; set; }
        public ConsoleColor Foreground { get; set; }
        public ConsoleColor Background { get; set; }

        public BodySegment() {
            this.BodyChar = ' ';
            this.Foreground = ConsoleColor.White;
            this.Background = ConsoleColor.Green;
        }

        public virtual void Update() {
        }

        public virtual void Draw(Screen screen, Vector parentPos) {
            screen.SetCell(parentPos + this.position, this.BodyChar, this.Foreground, this.Background);
        }
    }
}

