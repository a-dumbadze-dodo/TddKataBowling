namespace TddKataBowling {
    public class Roll {
        public Roll(int pins, int indexInFrame) {
            this.Pins = pins;
            this.IndexInFrame = indexInFrame;
        }
        public int Pins { get; }
        public int IndexInFrame { get; }

        public bool IsStrike() => this.Pins == 10 && IndexInFrame == 0;
    }
}