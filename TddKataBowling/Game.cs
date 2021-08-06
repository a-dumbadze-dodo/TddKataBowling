using System.Collections.Generic;
using System.Linq;

namespace TddKataBowling {

    public class Game {

        private List<Frame> _frames { get; }
        public Game() {
            this._frames = new List<Frame>() {
                new Frame()
            };
        }

        public void Roll(int knockedPins) {
            this.ValidateForMaximumFrames();
            var frame = CurrentFrame;
            if (CheckIfCompleted()) {
                frame = new Frame();
                this._frames.Add(frame);
            }
            frame.AddRoll(knockedPins);
        }

        private Frame CurrentFrame => this._frames.Last();
        private Frame PreviousFrame => this._frames.Count > 2 ? this._frames[^2] : null;

        private void ValidateForMaximumFrames() {
            if (this._frames.Count() == 10 && CurrentFrame.IsCompleted(PreviousFrame)) {
                throw new ConstraintGameException("More than 10 frames(20 rolls) per game");
            }
        }

        private bool CheckIfCompleted() {
            return this._frames.Count() == 10
                ? CurrentFrame.IsCompleted(PreviousFrame)
                : CurrentFrame.IsCompleted();
        }


        public int GetScore() {
            var t = _frames.ZipPreviousTuple()
                .Select(tuple => {
                    var (previousFrame, currentFrame) = tuple;
                    return currentFrame.GetScore(previousFrame);
                });

            return t.Sum();
        }
    }
}