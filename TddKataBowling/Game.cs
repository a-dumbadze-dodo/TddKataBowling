using System.Collections.Generic;
using System.Linq;

namespace TddKataBowling
{
	public class Game {
		private List<int> _score { get; set; }

		public Game() {
			this._score = new List<int>();
		}

		public void Roll(int knockedPins) {
			if (knockedPins > 10) {
				throw new TooManyKnockedPins("More than 10 pins are knocked in one roll");
			}
			
			if (this.IsSecondRoll() &&  GetLastScoreWithCurrentKnockedPins(knockedPins) > 10 ) {
					throw new TooManyKnockedPins("Pins count in 1 frame cannot be more than 10");
			}
			this._score.Add(knockedPins);
		}
		private bool IsSecondRoll() {
			var scoreWithoutStrikes = this._score.Where(x => x != 10);
			return scoreWithoutStrikes.Any() && scoreWithoutStrikes.Count() % 2 != 0;
		}
		private int GetLastScoreWithCurrentKnockedPins(int knockedPins) {
			return this._score.Last() + knockedPins;
		}
		public int GetScore()
		{
			return _score.ZipPreviousTriple()
				.Select(tuple =>
				{
					var (previous2KnockedPins, previousKnockedPins, currentKnockedPins) = tuple;
					var isSpare = previous2KnockedPins + previousKnockedPins == 10;
					var isStrike = previousKnockedPins == 10 || previous2KnockedPins == 10; 
					int result;
					if (isStrike || isSpare)
					{
						result = currentKnockedPins * 2;
					}
					else
					{
						result = currentKnockedPins;
					}

					return result;
				}).Sum();
		}
	}
}