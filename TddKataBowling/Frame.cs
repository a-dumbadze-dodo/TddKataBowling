using System.Collections.Generic;
using System.Linq;
namespace TddKataBowling {
    public class Frame {
        private readonly List<Roll> _rolls = new();
        public void AddRoll(int pins) {
            var roll = new Roll(pins, this._rolls.Count);
            if (roll.Pins > 10) {
                throw new TooManyKnockedPins("More than 10 pins are knocked in one roll");
            }
            if (this._rolls.Select(r => r.Pins).Sum() + roll.Pins > 10) {
                throw new TooManyKnockedPins("Pins count in 1 frame cannot be more than 10");
            }

            this._rolls.Add(roll);
        }
        public int GetScore(Frame previousFrame) {
            var score = 0;
            score += this._rolls.Select(x => x.Pins).Sum();
            if (previousFrame != null) {
                if (previousFrame.IsStrike()) {
                    score += this._rolls.Take(2).Select(x => x.Pins).Sum();
                } else if (previousFrame.IsSpare()) {
                    score += this._rolls.Take(1).Select(x => x.Pins).Sum();
                }
            }
            return score;
        }
        public bool IsCompleted(Frame previousFrame = null) {
            var canBeThreeRolls = (previousFrame?.IsSpare() ?? false) || (previousFrame?.IsStrike() ?? false);
            return (this._rolls.Count() == 2 && !canBeThreeRolls)
                   || (this._rolls.Count() == 3 && canBeThreeRolls)
                   || this.IsStrike();
        }
        public bool IsStrike() {
            return this._rolls.Any() && this._rolls.First().IndexInFrame == 0 && this._rolls.First().Pins == 10;
        }
        public bool IsSpare() {
            return (this._rolls.Count() == 2) && (this._rolls.Sum(x => x.Pins) == 10);
        }
    }
}