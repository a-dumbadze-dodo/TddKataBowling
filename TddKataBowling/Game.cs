using System.Collections.Generic;

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
			var result = 0;
			for (int i = 0; i < _score.Count; i++)
			{
				var currentKnockedPins = _score[i];
				var previousKnockedPins = i < 1 ? 0 : _score[i - 1];
				var previous2KnockedPins = i < 2 ? 0 : _score[i - 2];
				var isSpare = previous2KnockedPins + previousKnockedPins==10;
				if (previousKnockedPins == 10 || previous2KnockedPins == 10 || isSpare)
				{
					result += currentKnockedPins * 2;
				}
				else
				{
					result += currentKnockedPins;
				}
			}
			
			return result;
		}
	}
}