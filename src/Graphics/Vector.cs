using System;

namespace Snake.Graphics {
    public struct Vector {
        private readonly int x;
        private readonly int y;

        public int X => this.x;
        public int Y => this.y;

        public Vector(Vector v) : this(v.X, v.Y) {}

        public Vector(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public static Vector operator +(Vector v1, Vector v2) {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v1, Vector v2) {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector operator *(int s, Vector v) {
            return new Vector(s * v.X, s * v.Y);
        }

        public static Vector operator *(Vector v, int s) {
            return s * v;
        }

        public static Vector operator /(Vector v, int s) {
            return new Vector(v.X / s, v.Y / s);
        }

        public static Vector operator %(Vector v1, Vector v2) {
            int x = v1.X % v2.X;
            if (x < 0) x += v2.X;

            int y = v1.Y % v2.Y;
            if (y < 0) y += v2.Y;

            return new Vector(x, y);
        }

        public static bool operator ==(Vector v1, Vector v2) {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        public static bool operator !=(Vector v1, Vector v2) {
            return !(v1 == v2);
        }

        public override bool Equals(object o) {
            if (!(o is Vector)) return false;
            return this == (Vector)o;
        }

        public override int GetHashCode() {
            return this.X ^ this.Y;
        }

        public override string ToString() {
            return "(" + this.X.ToString() + ", " + this.Y.ToString() + ")";
        }
    }
}

