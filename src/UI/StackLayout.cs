using Snake.Graphics;

namespace Snake.UI {
    public class StackLayout : Layout {

        public StackLayout(Vector position, Vector size) : base(position, size) {}

        protected override void CalculateChildLayouts() {
            foreach (IPositionable child in this.children) {
                child.Position = new Vector();
                child.Size = this.Size;
            }
        }
    }
}

