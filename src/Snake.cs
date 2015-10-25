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

        private int ticksBetweenMoves;
        private int ticksUntilNextMove;

        public Vector GameAreaSize { get; set; }

        public SnakeBody(int startSpeed) {
            ticksBetweenMoves = startSpeed;
            ticksUntilNextMove = ticksBetweenMoves;

            this.head.GamePosition.X = 10;
            this.head.GamePosition.Y = 10;
            this.tail.GamePosition.X = 6;
            this.tail.GamePosition.Y = 10;

            BodySegment b1 = new BodySegment();
            b1.GamePosition.X = 9;
            b1.GamePosition.Y = 10;

            BodySegment b2 = new BodySegment();
            b2.GamePosition.X = 8;
            b2.GamePosition.Y = 10;

            BodySegment b3 = new BodySegment();
            b3.GamePosition.X = 7;
            b3.GamePosition.Y = 10;

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

                this.head.HeadDirection = this.MoveDirection;
            }

            if (ticksUntilNextMove <= 0) {
                this.Move();
                ticksUntilNextMove = ticksBetweenMoves;
            }
        }

        public void Move() {
            Vector oldHeadPos = this.head.GamePosition;

            this.head.GamePosition =  (this.head.GamePosition + this.MoveDirection.ToVector()) % this.GameAreaSize;

            BodySegment b = this.body.Pop();

            this.tail.GamePosition = b.GamePosition;

            b.GamePosition = oldHeadPos;
            this.body.Insert(0, b);
        }

        public void Draw(Screen screen, Vector parentPos) {
            foreach (BodySegment b in this.body) {
                b.Draw(screen, parentPos);
            }

            tail.Draw(screen, parentPos);
            head.Draw(screen, parentPos);
        }
    }
}

