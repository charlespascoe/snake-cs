using System;

namespace Snake {
    public class Cell {
        public char Character { get; set; }
        public ConsoleColor Foreground { get; set; }
        public ConsoleColor Background { get; set; }

        private char previousCharacter;
        private ConsoleColor previousForeground;
        private ConsoleColor previousBackground;

        public bool HasChanged {
            get {
                return this.Character != this.previousCharacter ||
                       this.Foreground != this.previousForeground ||
                       this.Background != this.previousBackground;
            }
        }

        public Cell() {
            this.Foreground = ConsoleColor.White;
            this.Background = ConsoleColor.Black;
            this.previousForeground = ConsoleColor.White;
            this.previousBackground = ConsoleColor.Black;
        }

        public Cell(char c, ConsoleColor f, ConsoleColor b) {
           this.Character = c;
           this.Foreground = f;
           this.Background = b;
        }

        public void AfterDraw() {
            this.previousCharacter = this.Character;
            this.previousForeground = this.Foreground;
            this.previousBackground = this.Background;
        }
    }
}

