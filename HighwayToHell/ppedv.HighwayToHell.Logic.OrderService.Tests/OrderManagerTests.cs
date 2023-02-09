namespace ppedv.HighwayToHell.Logic.OrderService.Tests
{
    public class OrderManagerTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(100, 0.2, 20)]
        [InlineData(200, 0.15, 30)]
        [InlineData(50, 0.1, 5)]
        public void CalculateVAT_ShouldReturnCorrectVATAmount(decimal price, decimal vatPercentage, decimal expectedVAT)
        {
            var om = new OrderManager(null);

            decimal actualVAT = om.CalculateVAT(price, vatPercentage);

            Assert.Equal(expectedVAT, actualVAT);
        }
    }
}