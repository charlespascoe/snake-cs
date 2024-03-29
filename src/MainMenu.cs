using System;
using System.Collections.Generic;
using Snake.Graphics;
using Snake.UI;

namespace Snake {
    public class MainMenu : Context {
        private List<IPositionable> elements = new List<IPositionable>();

        private Lense lense = new Lense();

        public MainMenu(Vector screenSize) : base(screenSize) {
            Button startBtn = new Button("Start");
            Button quitBtn = new Button("Quit");

            startBtn.OnClick += this.OnStartClick;
            quitBtn.OnClick += (sender, e) => Program.Quit();

            this.lense.AddChild(startBtn);
            this.lense.AddChild(quitBtn);

            this.elements.Add(
                new Container(size: screenSize, horizontalPos: HorizontalPosition.Center, verticalPos: VerticalPosition.Center, child:
                    new VerticalLayout(new Vector(), new Vector(32, 16)).Children(
                        startBtn,
                        quitBtn
                    )
                )
            );

            this.lense.Focus();
        }

        public override void Update() {
            foreach (IPositionable element in this.elements) {
                element.Update();
            }
        }

        public override void Draw(Screen screen) {
            foreach (IPositionable element in this.elements) {
                element.Draw(screen, new Vector());
            }
        }

        private void OnStartClick(object sender, EventArgs e) {
            Game g = new Game(this.ScreenSize, new DifficultySettings(5, 10, 10));
            this.FireChangeContext(new ChangeContextEventArgs(g));
        }
    }
}

