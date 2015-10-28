using System;

namespace Snake.Graphics {
    public interface IPositionable : IDrawable {
        Vector Position { get; set; }
        Vector Size { get; set; }
    }
}

