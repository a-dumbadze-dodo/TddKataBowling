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
		public void TestScore() {
			
			var knockedPins = 1;
			var game = new Game();
			
			game.Roll(knockedPins);
			
			var score = game.GetScore();
			
			Assert.AreEqual(score,knockedPins);
		}
	}
}