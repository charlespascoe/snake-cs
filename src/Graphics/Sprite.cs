using System;

namespace Snake.Graphics {
    public class Sprite : CellMatrix, IPositionable {
        public Vector Position { get; set; }

        public new Vector Size {
            get { return base.Size; }
            set {
                // Silently do nothing
            }
        }

        public Sprite(Vector position, Vector size) : base(size) {
            this.Position = position;
        }

        public Sprite(Vector position, Vector size, char defaultChar, Colour foreground, Colour background) : base(size, defaultChar, foreground, background) {
            this.Position = position;
        }

        public static Sprite FromStringArray(string[] spriteContent) {
            return Sprite.FromStringArray(spriteContent, Colour.White, Colour.Black);
        }

        public static Sprite FromStringArray(string[] spriteContent, Colour foreground, Colour background) {
            int height = spriteContent.Length;

            if (height == 0) return new Sprite(new Vector(), new Vector());

            int width = spriteContent[0].Length;

            if (width == 0) return new Sprite(new Vector(), new Vector());

            Sprite sprite = new Sprite(new Vector(), new Vector(width, height), ' ', foreground, background);

            for (int i = 0; i < height; i++) {
                if (spriteContent[i].Length != width) throw new Exception("Sprite content must be rectangular");

                sprite.DrawString(new Vector(0, i), spriteContent[i]);
            }

            return sprite;
        }

        public void Update() {

        }

        public void Draw(Screen screen, Vector parentPos) {
            screen.SetCells(parentPos + this.Position, this.cells);
        }
    }
}

