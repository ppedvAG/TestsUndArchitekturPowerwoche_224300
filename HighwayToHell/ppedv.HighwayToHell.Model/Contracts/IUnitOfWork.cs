namespace ppedv.HighwayToHell.Model.Contracts
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IRepository<Order> OrderRepository { get; }
        //... repos

        int SaveChanges();

        IRepository<T> GetRepo<T>() where T : Entity;
        
    }
}
