namespace Calculator.Tests_xUnit
{
    public class CalcTests
    {

        [Fact]
        [Trait("Category", "UnitTest")]
        public void Calc_Sum_3_and_4_results_7()
        {
            //Arrange
            InitTest();
            var calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            Assert.Equal(7, result);
            CleanUpTest();
        }

        private void CleanUpTest()
        {

        }

        private void InitTest()
        {

        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(100, 500, 600)]
        public void Sum(int a, int b, int exp)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.Equal(exp, result);
        }
    }
}