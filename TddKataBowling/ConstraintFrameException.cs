using System;

namespace TddKataBowling
{
	public class ConstraintFrameException : ConstraintGameException
	{
		public ConstraintFrameException()
		{
		}

		public ConstraintFrameException(string message) : base(message)
		{
		}
	}

    public class ConstraintGameException : Exception {
        public ConstraintGameException()
        {
        }

        public ConstraintGameException(string message) : base(message)
        {
        }
    }
	public class TooManyKnockedPins : ConstraintFrameException
	{
		public TooManyKnockedPins(string message) : base(message)
		{
		}
	}
}