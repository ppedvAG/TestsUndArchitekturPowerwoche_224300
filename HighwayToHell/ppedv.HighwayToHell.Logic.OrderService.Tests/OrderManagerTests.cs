using Moq;
using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

namespace ppedv.HighwayToHell.Logic.OrderService.Tests
{
    public class OrderManagerTests
    {

        [Fact]
        public void GetBestSellingMonth_December_wins()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Order>()).Returns(() =>
            {
                var o1 = new Order { OrderDate = new DateTime(2000, 4, 1) };
                o1.Items.Add(new OrderItem { Amount = 4, Price = 12 });
                var o2 = new Order { OrderDate = new DateTime(2000, 12, 1) };
                o2.Items.Add(new OrderItem { Amount = 2, Price = 14 });
                o2.Items.Add(new OrderItem { Amount = 2, Price = 12 });
                return new[] {o1, o2 }; 
            });

            var om = new OrderManager(mock.Object);

            var result = om.GetBestSellingMonth();

            Assert.Equal(12, result);
        }

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