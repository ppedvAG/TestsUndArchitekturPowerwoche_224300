using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

namespace ppedv.HighwayToHell.Logic.OrderService
{
    public class OrderManager
    {
        public IRepository Repository { get; }

        public OrderManager(IRepository repository)
        {
            Repository = repository;
        }

        public int GetBestSellingMonth()
        {
            return Repository.GetAll<Order>()
                             .GroupBy(order => order.OrderDate.Month)
                             .Select(group => new
                             {
                                 Month = group.Key,
                                 TotalSales = group.Sum(order => order.Items.Sum(item => item.Amount * item.Price))
                             })
                             .OrderByDescending(group => group.TotalSales)
                             .First()
                             .Month;
        }

        public decimal CalculateVAT(decimal price, decimal vatPercentage)
        {
            return price * vatPercentage;
        }
    }
}