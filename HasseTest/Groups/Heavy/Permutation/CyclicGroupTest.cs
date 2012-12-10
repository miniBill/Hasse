using Hasse;
using Hasse.Groups.Heavy.Permutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;

namespace HasseTest.Groups.Heavy.Permutation {
    [TestClass]
    public class CyclicGroupTest {
        [TestMethod]
        public void TestS1() {
            var g = new SymmetricGroup(0);
            Assert.AreEqual(1, g.Count());
            var builder = new StringBuilder();
            g.ForEach(element => builder.Append(element).Append('\n'));
            Assert.AreEqual("()\n", builder.ToString());
        }
    }
}
