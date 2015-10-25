using System;

namespace Snake {
    public class Tail : BodySegment {
        public Tail() {
            this.BodyCharRight = ' ';
            this.BodyCharLeft = ' ';
            this.Foreground = ConsoleColor.White;
            this.Background = ConsoleColor.Green;
        }
    }
}

