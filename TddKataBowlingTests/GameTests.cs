using NUnit.Framework;
using TddKataBowling;

namespace TddKataBowlingTests
{
	public class Tests
	{
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

		[Test]
		public void WhenRollSpareAnd3_ThenScore16() {
			var game = new Game();
			game.Roll(4);
			game.Roll(6);
			game.Roll(3);
			var score = game.GetScore();
			
			Assert.AreEqual(16,score);

		}

		[Test]
		public void WhenRollMoreThan10In1Frame_ThenConstraintFrameException() {
			var game = new Game();

			Assert.Throws<TooManyKnockedPins>(() => {
				game.Roll(6);
				game.Roll(6);
			});
		}

        [Test]
        public void WhenAdjacentRollsInTotalAreEqual10_ThenDontCountItAsASpare () {
            var game = new Game();
            game.Roll(3);
            game.Roll(5);
            game.Roll(5);
            game.Roll(1);

            var result = game.GetScore();
            
            Assert.AreEqual(14, result);
        }
	}
}