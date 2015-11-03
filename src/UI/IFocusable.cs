using System;

namespace Snake.UI {
    public class OnBlurEventArgs : EventArgs {}

    public delegate void OnBlurEventHander(object sender, OnBlurEventArgs e);

    public interface IFocusable {
        bool IsFocussed { get; }

        event OnBlurEventHander OnBlur;

        void Focus();

        void Blur(bool fireOnBlur=true);
    }
}

