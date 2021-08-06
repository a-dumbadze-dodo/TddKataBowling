using System.Collections.Generic;
using System.Linq;

namespace TddKataBowling {

    public class Game {
        private List<Roll> _score { get; }

        public Game() {
            this._score = new();
        }

        public void Roll(int knockedPins) {
            if (knockedPins > 10) {
                throw new TooManyKnockedPins("More than 10 pins are knocked in one roll");
            }

            if (this.IsSecondRoll() && GetLastScoreWithCurrentKnockedPins(knockedPins) > 10) {
                throw new TooManyKnockedPins("Pins count in 1 frame cannot be more than 10");
            }
            this._score.Add(new Roll(knockedPins, this.IsSecondRoll() ? 1 : 0));
        }

        private bool IsSecondRoll() {
            var scoreWithoutStrikes = this._score.Where(x => !x.IsStrike());
            return scoreWithoutStrikes.Any() && scoreWithoutStrikes.Count() % 2 != 0;
        }

        private int GetLastScoreWithCurrentKnockedPins(int knockedPins) {
            return this._score.Last().Pins + knockedPins;
        }

        private bool IsSpare(Roll roll, Roll secondRoll) {
            if (roll == null || secondRoll == null)
                return false;
            return roll.Pins + secondRoll.Pins == 10 && roll.IndexInFrame == 0 && secondRoll.IndexInFrame == 1;
        }

        private bool AnyIsStrike(Roll roll, Roll secondRoll) {
            return (roll?.IsStrike() ?? false)
                   || (secondRoll?.IsStrike() ?? false);
        }

        public int GetScore() {
            return _score.ZipPreviousTriple()
                .Select(tuple => {
                    var (previous2Roll, previousRoll, currentRoll) = tuple;
                    var isSpare = IsSpare(previous2Roll, previousRoll);
                    var isStrike = AnyIsStrike(previous2Roll, previousRoll);
                    int result;
                    if (isStrike || isSpare) {
                        result = currentRoll.Pins * 2;
                    } else {
                        result = currentRoll.Pins;
                    }

                    return result;
                }).Sum();
        }
    }
}