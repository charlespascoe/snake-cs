using System;

namespace Snake.Graphics {
    public class BoxStyle {
        public virtual char TopLeftCorner { get { return ' '; } }
        public virtual char BottomLeftCorner { get { return ' '; } }
        public virtual char TopRightCorner { get { return ' '; } }
        public virtual char BottomRightCorner { get { return ' '; } }
        public virtual char HorizontalBar { get { return ' '; } }
        public virtual char VerticalBar { get { return ' '; } }

        public Colour Foreground { get; set; }
        public Colour Background { get; set; }
        public Colour BorderForeground { get; set; }
        public Colour BorderBackground { get; set; }

        public bool HasBorder { get; set; }

        public BoxStyle() {
            this.Foreground = Colour.White;
            this.Background = Colour.Black;
            this.BorderForeground = Colour.White;
            this.BorderBackground = Colour.Black;
            this.HasBorder = true;
        }
    }
}
