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

        public void Write(string tag, string message) {
            StringBuilder str = new StringBuilder();
            str.Append("[").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("]");
            str.Append(" <").Append(tag).Append(">\n");
            str.Append(message);

            this.strm.WriteLineAsync(str.ToString());
        }

        public void Flush() {
            this.strm.Flush();
        }

        public void Close() {
            this.strm.Close();
        }
    }
}

