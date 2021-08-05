using System;
using System.Collections.Generic;
using System.Linq;
namespace TddKataBowling {
    public class Game {

        private List<int> _score { get; set; }
        public Game() {
            this._score = new List<int>();
        }
        public void Roll(int knockedPins) {
            this._score.Add(knockedPins);
        }
        public int GetScore() {
            return this._score.Sum();
        }
    }
}