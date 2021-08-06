using NUnit.Framework;
using TddKataBowling;

namespace TddKataBowlingTests {
    public class Tests {
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
            var game = Create.Game.WithRolls(10, 5, 3).Please();

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

            Assert.AreEqual(16, score);

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
        public void WhenAdjacentRollsInTotalAreEqual10_ThenDontCountItAsASpare() {
            var game = new Game();
            game.Roll(3);
            game.Roll(5);
            game.Roll(5);
            game.Roll(1);

            var result = game.GetScore();

            Assert.AreEqual(14, result);
        }

     
        [Test]
        public void WhenFrame9IsStrikeOrSpare_ThenFrame10RollCountCanBe3() {
            var game = new Game();
            
            for (var i = 0; i <= 16; i++) {
                game.Roll(1);
            }
            game.Roll(9); // 26
            
            game.Roll(3); // 26+6
            game.Roll(3); // 32+3
            game.Roll(3); // 35+3

            var result = game.GetScore();
            
            Assert.AreEqual(38,result);
        }
        [Test]
        public void WhenFrameCountMoreThan10_ThenConstraintGameException() {
            var game = new Game();
            for (var i = 0; i <= 18; i++) {
                game.Roll(1);
            }
            Assert.Throws<ConstraintGameException>(()=> {
                for (var i = 0; i <= 25; i++) {
                    game.Roll(1);
                }
            });
        }
    }
}