using System;

namespace Snake {
    public class Tail : BodySegment {
        public Tail() {
            this.BodyCharRight = ' ';
            this.BodyCharLeft = ' ';
            this.Foreground = Colour.White;
            this.Background = Colour.Green;
        }

        public void Dead() {
            this.Background = Colour.Red;
        }
    }
}

