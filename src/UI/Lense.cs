using System;
using System.Collections.Generic;

namespace Snake.UI {
    public class Lense : IFocusable {
        private List<IFocusable> elements = new List<IFocusable>();

        public bool IsFocussed { get; private set; }
        public bool LoopElements { get; set; }

        public event BlurEventHander OnBlur;

        public Lense() : this(true) {}

        public Lense(bool loopElements) {
            this.IsFocussed = false;
            this.LoopElements = loopElements;
        }

        public void AddChild(IFocusable child) {
            if (!this.elements.Contains(child)) {
                child.OnBlur += this.HandleElementBlur;
                this.elements.Add(child);
            }
        }

        public void Focus() {
            if (!this.IsFocussed) {
                if (this.elements.Count > 0) {
                    this.IsFocussed = true;
                    this.elements[0].Focus();
                } else {
                    this.Blur(new BlurEventArgs());
                }
            }
        }

        public void Blur(BlurEventArgs e = null) {
            foreach (IFocusable element in this.elements) {
                element.Blur();
            }

            this.IsFocussed = false;

            if (e != null && this.OnBlur != null) {
                this.OnBlur(this, e);
            }
        }

        private void HandleElementBlur(object sender, BlurEventArgs e) {
            int index = this.elements.IndexOf((IFocusable)sender);

            if (e.Direction == FocusDirection.Forward) {
                index++;
            } else {
                index--;
            }

            if (this.LoopElements) {
                index = (index + this.elements.Count) % this.elements.Count;
            }

            if (index < 0 || index >= this.elements.Count) {
                this.Blur(new BlurEventArgs(e.Direction));
            } else {
                this.elements[index].Focus();
            }
        }

    }
}

