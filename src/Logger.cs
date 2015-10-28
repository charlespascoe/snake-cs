using System;
using System.IO;
using System.Text;

namespace Snake {
    public class Logger {
        public static Logger Instance { get; set; }

        private StreamWriter strm;

        public Logger(string logFile) {
            FileStream fs = new FileStream(logFile, FileMode.OpenOrCreate, FileAccess.Write);

            this.strm = new StreamWriter(fs, Encoding.UTF8, 65536);
        }

        public static void Write(string tag, string message) {
            if (Logger.Instance != null) {
                Logger.Instance.WriteLog(tag, message);
            }
        }

        public void WriteLog(string tag, string message) {
            StringBuilder str = new StringBuilder();
            str.Append("[").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("]");
            str.Append(" <").Append(tag).Append(">\n");
            str.Append(message);

            this.strm.WriteLineAsync(str.ToString());
        }

        public static void Flush() {
            if (Logger.Instance != null) {
                Logger.Instance.FlushLog();
            }
        }

        public void FlushLog() {
            this.strm.Flush();
        }

        public static void Close() {
            if (Logger.Instance != null) {
                Logger.Instance.CloseLog();
            }
        }

        public void CloseLog() {
            this.strm.Close();
        }
    }
}

