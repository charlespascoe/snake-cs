using System;

namespace Snake {
    public class Tail : BodySegment {
        public Tail() {
            this.BodyChar = '#';
            this.Foreground = ConsoleColor.White;
            this.Background = ConsoleColor.DarkGreen;
        }
    }
}

