using System;

namespace Snake {
    public class Head : BodySegment {
        private Direction _HeadDirection = Direction.Up;
        public Direction HeadDirection {
            get { return this._HeadDirection; }
            set {
                this._HeadDirection = value;
                this.UpdateHeadDirection();
            }
        }

        public Head() : base() {
            this.HeadDirection = Direction.Up;
            this.Foreground = Colour.White;
            this.Background = Colour.Green;
        }

        private void UpdateHeadDirection() {
            switch (this._HeadDirection) {
                case Direction.Up:
                    // Unicode 'Dot Above'
                    this.BodyCharRight = (char)0x02D9;
                    this.BodyCharLeft = this.BodyCharRight;
                    break;
                case Direction.Left:
                    this.BodyCharRight = ' ';
                    this.BodyCharLeft = ':';
                    break;
                case Direction.Down:
                    this.BodyCharRight = '.';
                    this.BodyCharLeft = '.';
                    break;
                case Direction.Right:
                    this.BodyCharRight = ':';
                    this.BodyCharLeft = ' ';
                    break;
            }
        }

        public void Dead() {
            this.Background = Colour.Red;
        }
    }
}

