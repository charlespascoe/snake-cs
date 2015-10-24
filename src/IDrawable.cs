using System;

namespace Snake {
    public interface IDrawable {
        void Update();

        void Draw(Screen screen, Vector parentPos);
    }
}

