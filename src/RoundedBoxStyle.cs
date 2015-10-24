using System;

namespace Snake {
    public class RoundedBoxStyle : BoxStyle {
        public override char TopLeftCorner { get { return (char)0x256D; } }
        public override char BottomLeftCorner { get { return (char)0x2570; } }
        public override char TopRightCorner { get { return (char)0x256E; } }
        public override char BottomRightCorner { get { return (char)0x256F; } }
        public override char HorizontalBar { get { return (char)0x2500; } }
        public override char VerticalBar { get { return (char)0x2502; } }
    }
}

