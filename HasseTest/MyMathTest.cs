using Hasse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HasseTest {
    [TestClass]
    public class MyMathTest {
        [TestMethod]
        public void FactorialTest() {
            Assert.AreEqual(1u, MyMath.Factorial(0));
            Assert.AreEqual(1u, MyMath.Factorial(1));
            Assert.AreEqual(2u, MyMath.Factorial(2));
            Assert.AreEqual(6u, MyMath.Factorial(3));
            Assert.AreEqual(24u, MyMath.Factorial(4));
            Assert.AreEqual(120u, MyMath.Factorial(5));
        }
    }
}
