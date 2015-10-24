using System;

namespace Snake.Graphics {
    public class BoxStyle {
        public virtual char TopLeftCorner { get { return ' '; } }
        public virtual char BottomLeftCorner { get { return ' '; } }
        public virtual char TopRightCorner { get { return ' '; } }
        public virtual char BottomRightCorner { get { return ' '; } }
        public virtual char HorizontalBar { get { return ' '; } }
        public virtual char VerticalBar { get { return ' '; } }

        public ConsoleColor Foreground { get; set; }
        public ConsoleColor Background { get; set; }
        public ConsoleColor BorderForeground { get; set; }
        public ConsoleColor BorderBackground { get; set; }

        public BoxStyle() {
            this.Foreground = ConsoleColor.White;
            this.Background = ConsoleColor.Black;
            this.BorderForeground = ConsoleColor.White;
            this.BorderBackground = ConsoleColor.Black;
        }
    }
}
