using System;
using Snake.Graphics;

namespace Snake {
    public class BodySegment : IDrawable {
        public Vector Position { get; set; }

        public char BodyChar { get; set; }
        public ConsoleColor Foreground { get; set; }
        public ConsoleColor Background { get; set; }

        public BodySegment() {
            this.BodyChar = ' ';
            this.Foreground = ConsoleColor.White;
            this.Background = ConsoleColor.Green;
            this.Position = new Vector();
        }

        public virtual void Update() {
        }

        public virtual void Draw(Screen screen, Vector parentPos) {
            screen.SetCell(parentPos + this.Position, this.BodyChar, this.Foreground, this.Background);
        }
    }
}

