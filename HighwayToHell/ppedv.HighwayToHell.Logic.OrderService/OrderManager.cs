using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

namespace ppedv.HighwayToHell.Logic.OrderService
{
    public class OrderManager : IOrderManager
    {
        public IUnitOfWork UnitOfWork { get; }

        public OrderManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public int GetBestSellingMonth()
        {
            //return UnitOfWork.OrderRepository.GetAll()
            return UnitOfWork.GetRepo<Order>().GetAll()
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