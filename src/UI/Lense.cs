using System;
using System.Collections.Generic;

namespace Snake.UI {
    public class Lense : IFocusable {
        private List<IFocusable> elements = new List<IFocusable>();

        public bool IsFocussed { get; private set; }
        public bool LoopElements { get; set; }

        public event OnBlurEventHander OnBlur;

        public Lense() : this(true) {}

        public Lense(bool loopElements) {
            this.IsFocussed = false;
            this.LoopElements = loopElements;
        }

        public void AddChild(IFocusable child) {
            if (!this.elements.Contains(child)) {
                child.OnBlur += new OnBlurEventHander(this.HandleElementBlur);
                this.elements.Add(child);
            }
        }

        public void Focus() {
            this.Blur(false);

            if (this.elements.Count > 0) {
                this.IsFocussed = true;
                this.elements[0].Focus();
            } else {
                this.Blur();
            }
        }

        public void Blur(bool fireOnBlur=true) {
            foreach (IFocusable element in this.elements) {
                element.Blur(false);
            }

            this.IsFocussed = false;

            if (fireOnBlur && this.OnBlur != null) {
                this.OnBlur(this, new OnBlurEventArgs());
            }
        }

        private void HandleElementBlur(object sender, OnBlurEventArgs e) {
            int index = this.elements.IndexOf((IFocusable)sender);
            Logger.Write("Lense", index.ToString());

            if (index == this.elements.Count - 1) {
                if (this.LoopElements) {
                    this.Focus();
                } else {
                    this.Blur();
                }
            } else {
                this.elements[index + 1].Focus();
            }
        }

    }
}

