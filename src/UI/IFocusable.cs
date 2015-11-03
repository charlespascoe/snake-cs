using System;

namespace Snake.UI {
    public enum FocusDirection {
        Forward, Backward
    }

    public class OnBlurEventArgs : EventArgs {
        public FocusDirection Direction { get; set; }

        public OnBlurEventArgs() {
            this.Direction = FocusDirection.Forward;
        }

        public OnBlurEventArgs(FocusDirection focusDirection) {
            this.Direction = focusDirection;
        }
    }

    public delegate void OnBlurEventHander(object sender, OnBlurEventArgs e);

    public interface IFocusable {
        bool IsFocussed { get; }

        event OnBlurEventHander OnBlur;

        void Focus();

        void Blur(OnBlurEventArgs e = null);
    }
}

