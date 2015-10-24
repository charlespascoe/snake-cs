using System;

namespace Snake {
    public abstract class BoxStyle {
        public virtual char TopLeftCorner { get; }
        public virtual char BottomLeftCorner { get; }
        public virtual char TopRightCorner { get; }
        public virtual char BottomRightCorner { get; }
        public virtual char HorizontalBar { get; }
        public virtual char VerticalBar { get; }
    }
}
