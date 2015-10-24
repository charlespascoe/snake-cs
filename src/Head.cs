using System;

namespace Snake {
    public class Head : BodySegment {
        private Direction _HeadDirection = Direction.Up;
        public Direction HeadDirection {
            get { return this._HeadDirection; }
            set {
                this._HeadDirection = value;

                switch (value) {
                    case Direction.Up:
                        this.BodyChar = 'v';
                        break;
                    case Direction.Left:
                        this.BodyChar = '>';
                        break;
                    case Direction.Down:
                        this.BodyChar = '^';
                        break;
                    case Direction.Right:
                        this.BodyChar = '<';
                        break;
                }
            }
        }

        public Head() {
            this.BodyChar = '<';
            this.Foreground = ConsoleColor.White;
            this.Background = ConsoleColor.DarkGreen;
        }
    }
}

