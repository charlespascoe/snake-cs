using System;

namespace Snake.Graphics {
    public interface IDrawable {
        void Update();

        void Draw(Screen screen, Vector parentPos);
    }
}

