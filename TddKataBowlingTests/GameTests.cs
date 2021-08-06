using System.Reflection.PortableExecutable;
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
		public void WhenRollStrikeAnd5And3_ThanScore26() {
			var game = new Game();
			
			game.Roll(10); // 10
			game.Roll(5);  // 10
			game.Roll(3);  // 6
			var score = game.GetScore();
			
			Assert.AreEqual(26,score);
		}

		[Test]
		public void WhenRollSpareAnd3_ThanScore16() {
			var game = new Game();
			game.Roll(4);
			game.Roll(6);
			game.Roll(3);
			var score = game.GetScore();
			
			Assert.AreEqual(score,16);

		}
	}
}