
namespace CalculatorTest
{
    [TestClass]
    public class CalculationsTest
    {
        Calculations cs = new Calculations();

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            cs.Divide(8, 0);
        }

        [TestMethod]
        public void MultiplyWorks()
        {
            Assert.AreEqual(4, cs.Multiply(2, 2));
        }
        [TestMethod]
        public void AdditionWorks()
        {
            Assert.AreEqual(4, cs.Addition(2, 2));
        }
        [TestMethod]
        public void SubtractionWorks()
        {
            Assert.AreEqual(4, cs.Subtract(6, 2));
        }
        [TestMethod]
        public void DivisionWorks()
        {
            Assert.AreEqual(4, cs.Divide(8, 2));
        }
    }
}