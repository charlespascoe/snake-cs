using System;

namespace Snake {
    public class Cell {
        public char character;
        public ConsoleColor foreground;
        public ConsoleColor background;

        private char previousCharacter;
        private ConsoleColor previousForeground;
        private ConsoleColor previousBackground;

        public bool HasChanged {
            get {
                return this.character != this.previousCharacter ||
                       this.foreground != this.previousForeground ||
                       this.background != this.previousBackground;
            }
        }

        public Cell() {
            this.foreground = ConsoleColor.White;
            this.background = ConsoleColor.Black;
            this.previousForeground = ConsoleColor.White;
            this.previousBackground = ConsoleColor.Black;
        }

        public Cell(char c, ConsoleColor f, ConsoleColor b) {
           this.character = c;
           this.foreground = f;
           this.background = b;
        }

        public void AfterDraw() {
            this.previousCharacter = this.character;
            this.previousForeground = this.foreground;
            this.previousBackground = this.background;
        }
    }
}

