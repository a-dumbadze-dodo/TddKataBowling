using NUnit.Framework;
using TddKataBowling;

namespace TddKataBowlingTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
			
			
		}

		[Test]
		public void WhenRoll1_ThenScore1() {
			var knockedPins = 1;
			var game = new Game();
			
			game.Roll(knockedPins);
			var score = game.GetScore();
			
			Assert.AreEqual(knockedPins, score);
		}
		
		[Test]
		public void WhenRollStrikeAnd5And3_ThenScore26() {
			var game = new Game();
			
			game.Roll(10); // 10
			game.Roll(5);  // 10
			game.Roll(3);  // 6
			var score = game.GetScore();
			
			Assert.AreEqual(26,score);
		}
	}
}