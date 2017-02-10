using System;

namespace Snake.Graphics {
    public class Cell {
        public char Character { get; set; }
        public Colour Foreground { get; set; }
        public Colour Background { get; set; }

        private char previousCharacter;
        private Colour previousForeground;
        private Colour previousBackground;

        public bool HasChanged {
            get {
                return this.Character != this.previousCharacter ||
                       this.Foreground != this.previousForeground ||
                       this.Background != this.previousBackground;
            }
        }

        public Cell() {
            this.Foreground = Colour.White;
            this.Background = Colour.Black;
            this.previousForeground = Colour.White;
            this.previousBackground = Colour.Black;
        }

        public Cell(char c, Colour f, Colour b) {
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

