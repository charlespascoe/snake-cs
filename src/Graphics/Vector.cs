using System;

namespace Snake.Graphics {
    public class Vector {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector() : this(0, 0) {}

        public Vector(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public static Vector operator +(Vector v1, Vector v2) {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v1, Vector v2) {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector operator %(Vector v1, Vector v2) {
            return new Vector(v1.X % v2.X, v1.Y % v2.Y);
        }
    }
}

