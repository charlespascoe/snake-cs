using System;
using Snake.Graphics;

namespace Snake {
    public abstract class GameEntity : IDrawable {
        public virtual Vector GamePosition { get; set; }

        public abstract void Update();

        public abstract void Draw(Screen screen, Vector parentPos);
    }
}

