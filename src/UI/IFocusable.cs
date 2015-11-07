using System;

namespace Snake.UI {
    public enum FocusDirection {
        Forward, Backward
    }

    public class BlurEventArgs : EventArgs {
        public FocusDirection Direction { get; set; }

        public BlurEventArgs() {
            this.Direction = FocusDirection.Forward;
        }

        public BlurEventArgs(FocusDirection focusDirection) {
            this.Direction = focusDirection;
        }
    }

    public delegate void BlurEventHander(object sender, BlurEventArgs e);

    public interface IFocusable {
        bool IsFocussed { get; }

        event BlurEventHander OnBlur;

        void Focus();

        void Blur(BlurEventArgs e = null);
    }
}

