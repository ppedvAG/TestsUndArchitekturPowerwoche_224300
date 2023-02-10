namespace ppedv.HighwayToHell.Model.Contracts
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetAllCarsFromTheNiceStoredProcedure();
    }
}
