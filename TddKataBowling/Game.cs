using System;
using System.Collections.Generic;
using System.Linq;

namespace TddKataBowling
{
	public class Game
	{
		private List<int> _score { get; set; }

		public Game()
		{
			this._score = new List<int>();
		}

		public void Roll(int knockedPins)
		{
			this._score.Add(knockedPins);
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