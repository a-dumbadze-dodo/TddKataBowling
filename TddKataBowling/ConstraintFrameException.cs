using System;

namespace TddKataBowling
{
	public class ConstraintFrameException : Exception
	{
		public ConstraintFrameException()
		{
		}

		public ConstraintFrameException(string message) : base(message)
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