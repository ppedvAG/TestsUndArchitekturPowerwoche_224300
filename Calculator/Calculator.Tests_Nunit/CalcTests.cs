namespace Calculator.Tests_Nunit
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [Category("UnitTest")]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            //Assert.AreEqual(7, result);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        [TestCase(int.MaxValue, 1)]
        [TestCase(1, int.MaxValue)]
        [TestCase(int.MinValue, -1)]
        [TestCase(-1, int.MinValue)]
        public void Sum_throws_OverflowExceptions(int a, int b)
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));
        }
    }
}