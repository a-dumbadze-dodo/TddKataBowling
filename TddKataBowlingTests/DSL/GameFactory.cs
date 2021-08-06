using TddKataBowling;
namespace TddKataBowlingTests {
    public class GameFactory {
        private int[] _rolls = new int[0];

        public GameFactory WithRolls(params int[] rolls) {
            this._rolls = rolls;
            return this;
        }

        public Game Please() {
            var game = new Game();
            foreach (var roll in this._rolls) {
                game.Roll(roll);
            }
            return game;
        }
    }
}