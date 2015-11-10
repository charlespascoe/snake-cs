using System;

namespace Snake.Graphics {
    public class Padding {
        public int Top { get; private set; }
        public int Right { get; private set; }
        public int Bottom { get; private set; }
        public int Left { get; private set; }

        public Padding() : this(0, 0, 0, 0) {}

        public Padding(int top, int right, int bottom, int left) {
            this.Top = top < 0 ? 0 : top;
            this.Right = right < 0 ? 0 : right;
            this.Bottom = bottom < 0 ? 0 : bottom;
            this.Left = left < 0 ? 0 : left;
        }

        public static bool operator ==(Padding p1, Padding p2) {
            if ((object)p1 == null || (object)p2 == null) {
                return (object)p1 == null && (object)p2 == null;
            }

            return
                p1.Top == p2.Top &&
                p1.Right == p2.Right &&
                p1.Bottom == p2.Bottom &&
                p1.Left == p2.Left;
        }

        public static bool operator !=(Padding p1, Padding p2) {
            return !(p1 == p2);
        }
    }
}
