using System;
using System.Collections.Generic;
using Snake.Graphics;

namespace Snake {
    public static class Extensions {
        public static Vector ToVector(this Direction direction) {
            switch (direction) {
                case Direction.Up:
                    return new Vector(0, -1);
                case Direction.Down:
                    return new Vector(0, 1);
                case Direction.Left:
                    return new Vector(-1, 0);
                case Direction.Right:
                    return new Vector(1, 0);
                default:
                    return new Vector();
            }
        }

        public static T Pop<T>(this List<T> list, int index) {
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        public static T Pop<T>(this List<T> list) {
            return list.Pop(list.Count - 1);
        }
    }
}

