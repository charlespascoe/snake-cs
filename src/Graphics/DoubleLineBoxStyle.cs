using System;

namespace Snake.Graphics {
    public class DoubleLineBoxStyle : BoxStyle {
        public override char TopLeftCorner { get { return (char)0x2554; } }
        public override char BottomLeftCorner { get { return (char)0x255A; } }
        public override char TopRightCorner { get { return (char)0x2557; } }
        public override char BottomRightCorner { get { return (char)0x255D; } }
        public override char HorizontalBar { get { return (char)0x2550; } }
        public override char VerticalBar { get { return (char)0x2551; } }

        public DoubleLineBoxStyle() : base() { }
    }
}

