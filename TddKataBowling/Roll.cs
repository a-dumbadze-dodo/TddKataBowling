using System.Collections.Generic;
using System.Linq;
namespace TddKataBowling {
    public class Roll {
        public Roll(int pins, int indexInFrame) {
            this.Pins = pins;
            this.IndexInFrame = indexInFrame;
        }
        public int Pins { get; }
        public int IndexInFrame { get; }

        public bool IsStrike() => this.Pins == 10 && IndexInFrame == 0;
    }

    public class Frame {
        private List<Roll> _rolls = new List<Roll>();
        public void AddRoll(Roll roll) {
            this._rolls.Add(roll);
        }
        public int GetScore(Frame previousFrame) {
            var score = 0;
            score += this._rolls.Select(x => x.Pins).Sum();
            if (previousFrame.IsStrike()) {
                score += this._rolls.Take(2).Select(x => x.Pins).Sum();
            } else if (previousFrame.IsSpare()) {
                score += this._rolls.Take(1).Select(x => x.Pins).Sum();
            }
            return score;
        }
        public bool IsCompleted() {
            return this._rolls.Count() == 2 || this.IsStrike();
        }
        private bool IsStrike() {
            return this._rolls.Any() && this._rolls.First().IndexInFrame == 0 && this._rolls.First().Pins == 10;
        }
        private bool IsSpare() {
            return (this._rolls.Count() == 2) && (this._rolls.Sum(x => x.Pins) == 10);
        }
    }
}