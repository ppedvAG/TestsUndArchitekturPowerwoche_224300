namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        [DataRow(0, 0, 0)]
        [DataRow(1, 2, 3)]
        [DataRow(-1, -2, -3)]
        [DataRow(100, 500, 600)]
        public void Sum(int a, int b, int exp)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

           Assert.AreEqual(exp, result);
        }

    }
}