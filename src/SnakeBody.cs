using System;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class SnakeBody : IDrawable {
        private Head head = new Head();
        private Tail tail = new Tail();
        private List<BodySegment> body = new List<BodySegment>();

        private Direction _MoveDirection = Direction.Up;
        public Direction MoveDirection {
            get { return this._MoveDirection; }
            set {
                this.SetDirection(value);
            }
        }

        private int ticksBetweenMoves;
        private int ticksUntilNextMove;

        public Vector GameAreaSize { get; private set; }

        public SnakeBody(int startSpeed, Vector gameAreaSize) {
            ticksBetweenMoves = startSpeed;
            ticksUntilNextMove = ticksBetweenMoves;

            this.GameAreaSize = gameAreaSize;

            Vector pos = new Vector(this.GameAreaSize.X / 2, this.GameAreaSize.Y / 2);

            this.head.GamePosition = new Vector(pos);


            for (int i = 0; i < 3; i++) {
                pos += new Vector(0, 1);
                BodySegment b = new BodySegment();
                b.GamePosition = pos;
                this.body.Add(b);
            }

            this.tail = new Tail();
            this.tail.GamePosition = pos + new Vector(0, 1);
        }

        public void Update() {
            ticksUntilNextMove--;

            if (UserInput.KeyPressed) {
                switch (UserInput.Key) {
                    case ConsoleKey.W:
                        this.SetDirection(Direction.Up);
                        break;
                    case ConsoleKey.A:
                        this.SetDirection(Direction.Left);
                        break;
                    case ConsoleKey.S:
                        this.SetDirection(Direction.Down);
                        break;
                    case ConsoleKey.D:
                        this.SetDirection(Direction.Right);
                        break;
                }
            }

            if (ticksUntilNextMove <= 0) {
                this.Move();
                ticksUntilNextMove = ticksBetweenMoves;
            }
        }

        private void SetDirection(Direction dir) {
            // Body segment just behind the head
            BodySegment b = this.body[0];

            if (b.GamePosition != (this.head.GamePosition + dir.ToVector()) % this.GameAreaSize) {
                this._MoveDirection = dir;
                this.head.HeadDirection = dir;
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

