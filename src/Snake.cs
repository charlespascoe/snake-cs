using System;
using System.Collections.Generic;
using Snake.Graphics;

namespace Snake {
    public class SnakeBody : IDrawable {
        private Head head = new Head();
        private Tail tail = new Tail();
        private List<BodySegment> body = new List<BodySegment>();

        public SnakeBody() {
            this.head.Position.X = 10;
            this.head.Position.Y = 10;
            this.tail.Position.X = 6;
            this.tail.Position.Y = 10;

            BodySegment b1 = new BodySegment();
            b1.Position.X = 9;
            b1.Position.Y = 10;

            BodySegment b2 = new BodySegment();
            b2.Position.X = 8;
            b2.Position.Y = 10;

            BodySegment b3 = new BodySegment();
            b3.Position.X = 7;
            b3.Position.Y = 10;

            this.body.Add(b1);
            this.body.Add(b2);
            this.body.Add(b3);
        }

        public void Update() {

        }

        public void Draw(Screen screen, Vector parentPos) {
            foreach (BodySegment b in this.body) {
                b.Draw(screen, parentPos);
            }

            head.Draw(screen, parentPos);
            tail.Draw(screen, parentPos);
            screen.SetCell(screen.Width - 1, screen.Height - 1, ' ');
        }
    }
}

