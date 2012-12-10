using Hasse;
using Hasse.Groups.Heavy.Permutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace HasseTest.Groups.Heavy.Permutation {
	[TestClass]
	public class CyclicGroupTest {
		[TestMethod]
		public void TestS0() {
			TestSn(0u, 1, "()\n", "{()}\n");
		}

		[TestMethod]
		public void TestS1() {
			TestSn(1u, 1, "()\n", "{()}\n");
		}

		[TestMethod]
		public void TestS2() {
			TestSn(2u, 2, "()\n(1 2)\n", "{()}\n{(), (1 2)}\n");
		}

		[TestMethod]
		public void TestS3() {
			TestSn(3u, 6, "()\n(1 2)\n(1 3 2)\n(2 3)\n(1 2 3)\n(1 3)\n", "{()}\n" +
				"{(), (1 2)}\n{(), (2 3)}\n{(), (1 3)}\n{(), (1 2 3), (1 3 2)}\n" +
				"{(), (1 2), (1 3), (2 3), (1 2 3), (1 3 2)}\n");
		}

		private static void TestSn(uint size, int count, string expectedElements, string expectedSubgroups) {
			var @group = new SymmetricGroup(size);

			Assert.AreEqual(count, @group.Count());

			var builder = new StringBuilder();
			@group.ForEach(element => builder.Append(element).Append('\n'));
			Assert.AreEqual(expectedElements, builder.ToString());

			builder.Clear();
			var gen = GeneratorFactory.Create(@group);
			gen.Generate().OrderBy(subgroup => subgroup.Order).ForEach(subgroup => builder.Append(subgroup).Append('\n'));
			Assert.AreEqual(expectedSubgroups, builder.ToString());
		}
	}
}
