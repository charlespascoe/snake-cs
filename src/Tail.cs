using System;

namespace Snake {
    public class Tail : BodySegment {
        public Tail() {
            this.BodyCharRight = ' ';
            this.BodyCharLeft = ' ';
            this.Foreground = Colour.White;
            this.Background = new Colour(0, 2, 0);
        }

        public void Dead() {
            this.Background = new Colour(5, 0, 0);
        }
    }
}

