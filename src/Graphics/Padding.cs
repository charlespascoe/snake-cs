namespace Snake.Graphics {
    public struct Padding {
        private readonly int top;
        private readonly int right;
        private readonly int bottom;
        private readonly int left;

        public int Top { get { return this.top; } }
        public int Right { get { return this.right; } }
        public int Bottom { get { return this.bottom; } }
        public int Left { get { return this.left; } }

        public Padding(int top, int right, int bottom, int left) {
            this.top = top < 0 ? 0 : top;
            this.right = right < 0 ? 0 : right;
            this.bottom = bottom < 0 ? 0 : bottom;
            this.left = left < 0 ? 0 : left;
        }

        public static bool operator ==(Padding p1, Padding p2) {
            return
                p1.Top == p2.Top &&
                p1.Right == p2.Right &&
                p1.Bottom == p2.Bottom &&
                p1.Left == p2.Left;
        }

        public static bool operator !=(Padding p1, Padding p2) {
            return !(p1 == p2);
        }

        public override bool Equals(object o) {
            if (!(o is Padding)) return false;
            return this == (Padding)o;
        }

        public override int GetHashCode() {
            return this.Top ^ this.Right ^ this.Bottom ^ this.Left;
        }
    }
}
