using System;

namespace Snake.UI {
    public static class UserInput {
        public static bool KeyPressed { get; private set; }

        public static char KeyChar { get; private set; }
        public static ConsoleKey Key { get; private set; }

        public static bool ControlPressed { get; private set; }
        public static bool ShiftPressed { get; private set; }
        public static bool AltPressed { get; private set; }

        public static void Update() {
            UserInput.KeyPressed = Console.KeyAvailable;
            if (Console.KeyAvailable) {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                UserInput.KeyChar = cki.KeyChar;
                UserInput.Key = cki.Key;

                UserInput.ControlPressed = (cki.Modifiers & ConsoleModifiers.Control) > 0;
                UserInput.ShiftPressed = (cki.Modifiers & ConsoleModifiers.Shift) > 0;
                UserInput.AltPressed = (cki.Modifiers & ConsoleModifiers.Alt) > 0;
            }
        }
    }
}

