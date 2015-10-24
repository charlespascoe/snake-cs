using System;

namespace Snake {
    public class Head : BodySegment {
        public Head() {
            this.BodyChar = '<';
            this.Foreground = ConsoleColor.White;
            this.Background = ConsoleColor.DarkGreen;
        }
    }
}

