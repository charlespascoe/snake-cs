using System;

namespace Snake {
    public interface IDrawable {
        bool hasChanged { get; }

        void Update();

        void Draw(Screen screen);
    }
}

