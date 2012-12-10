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
            TestSn(0u, 1, "()\n");
        }

        [TestMethod]
        public void TestS1() {
            TestSn(1u, 1, "()\n");
        }

        [TestMethod]
        public void TestS2() {
            TestSn(2u, 2, "()\n(1 2)\n");
        }

        [TestMethod]
        public void TestS3() {
            TestSn(3u, 6, "()\n(1 2)\n(1 3 2)\n(2 3)\n(1 2 3)\n(1 3)\n");
        }

        [TestMethod]
        public void TestS4() {
            TestSn(4u, 24, "()\n(1 2)\n(1 3 2)\n(1 4 3 2)\n(2 3)\n(1 2 3)\n(1 3)\n(1 4 3)\n(2 4 3)\n" +
                           "(1 2 4 3)\n(1 3)(2 4)\n(1 4 2 3)\n(3 4)\n(1 2)(3 4)\n(1 3 4 2)\n(1 4 2)\n" +
                           "(2 3 4)\n(1 2 3 4)\n(1 3 4)\n(1 4)\n(2 4)\n(1 2 4)\n(1 3 2 4)\n(1 4)(2 3)\n");
        }

        private static void TestSn(uint size, int count, string expected) {
            var g = new SymmetricGroup(size);
            Assert.AreEqual(count, g.Count());
            var builder = new StringBuilder();
            g.ForEach(element => builder.Append(element).Append('\n'));
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}
