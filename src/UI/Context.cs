using System;
using Snake.Graphics;

namespace Snake.UI {
    public class ChangeContextEventArgs : EventArgs {
        public Context NewContext { get; private set; }

        public ChangeContextEventArgs(Context newContext) {
            this.NewContext = newContext;
        }
    }

    public delegate void ChangeContextEventHandler(object sender, ChangeContextEventArgs e);

    public abstract class Context {
        public event ChangeContextEventHandler OnChangeContext;

        public Vector ScreenSize { get; private set; }

        public Context(Vector screenSize) {
            this.ScreenSize = screenSize;
        }

        public abstract void Update();

        public abstract void Draw(Screen screen);
    }
}

