namespace ppedv.HighwayToHell.Model.Contracts
{
    public interface IOrderManager
    {
        decimal CalculateVAT(decimal price, decimal vatPercentage);
        int GetBestSellingMonth();
    }
}