

namespace ppedv.HighwayToHell.Logic.OrderService
{
    public class OrderManager
    {
        public decimal CalculateVAT(decimal price, decimal vatPercentage)
        {
            return price * vatPercentage;
        }

        public int GetBestSellingMonth()
        {

            throw new NotImplementedException();
        }
    }
}