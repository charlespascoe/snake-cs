using System;
using System.Threading;

namespace Snake {
    public class Program {
        public static void Main(string[] args) {
            Console.CursorVisible = false;
            int pos = 0;
            while (true) {
                Console.Clear();
                Console.SetCursorPosition(pos, pos);
                Console.Write('X');

                pos = (pos + 1) % Console.WindowHeight;
                Thread.Sleep(50);
            }
        }
    }
}

