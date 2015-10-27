using System;

namespace Snake {
    public class DifficultySettings {
        public int PointsBetweenSpeedup { get; set; }
        public int StartSpeed { get; set; }
        public int FoodCount { get; set; }

        public DifficultySettings() {}

        public DifficultySettings(int pointsBetweenSpeedup, int startSpeed, int foodCount) {
            this.PointsBetweenSpeedup = pointsBetweenSpeedup;
            this.StartSpeed = startSpeed;
            this.FoodCount = foodCount;
        }
    }
}

