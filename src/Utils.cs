using System;

namespace Snake {
    public static class Utils {
        public static string CenterString(string text, int length) {
            if (text.Length >= length) return text.Substring(0, length);

            int padding = length - text.Length;

            string result = new String(' ', padding / 2) + text + new String(' ', padding / 2);

            if (result.Length < length) {
                result += " ";
            }

            return result;
        }
    }
}

