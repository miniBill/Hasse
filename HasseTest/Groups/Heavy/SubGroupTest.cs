using System;
using Hasse.Groups.Heavy;
using Hasse.Groups.Heavy.Permutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HasseTest.Groups.Heavy {
	[TestClass]
	public class SubGroupTest {
		[TestMethod]
		public void TestIncrement() {
			var array = new[] { 0u };
			Assert.IsTrue(SubGroup<SymmetricElement>.Increment(array, 2));
			CollectionAssert.AreEqual(new[] { 1u }, array);
			Assert.IsFalse(SubGroup<SymmetricElement>.Increment(array, 2));
			CollectionAssert.AreEqual(new[] { 0u }, array);
		}
	}
}
