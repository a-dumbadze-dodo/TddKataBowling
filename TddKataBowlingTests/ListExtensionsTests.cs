using System.Collections.Generic;
using NUnit.Framework;
using TddKataBowling;

namespace TddKataBowlingTests
{
	public class ListExtensionsTests
	{
		[Test]
		public void WhenThreeElements_ReturnThreeTriples()
		{
			var result = new List<int> {1, 2, 3}.ZipPreviousTriple();

			Assert.AreEqual(
				expected: new List<(int first, int second, int third)> {(0, 0, 1), (0, 1, 2), (1, 2, 3)},
				actual: result
			);
		}
		
		[Test]
		public void WhenOneElement_ReturnOneTriple()
		{
			var result = new List<int> {1}.ZipPreviousTriple();

			Assert.AreEqual(
				expected: new List<(int first, int second, int third)> {(0, 0, 1)},
				actual: result
			);
		}
		
		[Test]
		public void WhenFiveElements_ReturnFiveTriples()
		{
			var result = new List<int> {1, 2, 3, 4, 5}.ZipPreviousTriple();

			Assert.AreEqual(
				expected: new List<(int first, int second, int third)>
				{
					(0, 0, 1), (0, 1, 2), (1, 2, 3), (2, 3, 4), (3, 4, 5)
				},
				actual: result
			);
		}
	}
}