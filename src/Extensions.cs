using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

        public static String MaxLength(this string text, int maxLength) {
            return text.Length > maxLength ? text.Substring(0, maxLength) : text;
        }

        public static String Center(this string text, int length) {
            if (text.Length >= length) return text;

            int padding = length - text.Length;

            string result = new String(' ', padding / 2) + text + new String(' ', padding / 2);

            if (result.Length < length) {
                result += ' ';
            }

            return result;
        }

        public static String LeftPad(this string text, char padding, int length) {
            int addPadding = length - text.Length;
            return addPadding <= 0 ? text : new String(padding, addPadding) + text;
        }

        public static String RightPad(this string text, char padding, int length) {
            int addPadding = length - text.Length;
            return addPadding <= 0 ? text : text + new String(padding, addPadding);
        }

        public static void Write(this Stream strm, string str) {
            byte[] data = Encoding.UTF8.GetBytes(str);
            strm.Write(data, 0, data.Length);
        }
    }
}

