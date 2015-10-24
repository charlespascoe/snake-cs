using System;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class SnakeBody : IDrawable {
        private Head head = new Head();
        private Tail tail = new Tail();
        private List<BodySegment> body = new List<BodySegment>();

        public Direction MoveDirection { get; set; }

        private int ticksBetweenMoves = 10;
        private int ticksUntilNextMove = 10;

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
            ticksUntilNextMove--;

            if (UserInput.KeyPressed) {
                switch (UserInput.Key) {
                    case ConsoleKey.W:
                        this.MoveDirection = Direction.Up;
                        break;
                    case ConsoleKey.A:
                        this.MoveDirection = Direction.Left;
                        break;
                    case ConsoleKey.S:
                        this.MoveDirection = Direction.Down;
                        break;
                    case ConsoleKey.D:
                        this.MoveDirection = Direction.Right;
                        break;
                }
            }

            if (ticksUntilNextMove <= 0) {
                this.Move();
                ticksUntilNextMove = ticksBetweenMoves;
            }
        }

        public void Move() {
            Vector oldHeadPos = this.head.Position;

            this.head.Position += this.MoveDirection.ToVector();

            BodySegment b = this.body.Pop();

            this.tail.Position = b.Position;

            b.Position = oldHeadPos;
            this.body.Insert(0, b);
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

