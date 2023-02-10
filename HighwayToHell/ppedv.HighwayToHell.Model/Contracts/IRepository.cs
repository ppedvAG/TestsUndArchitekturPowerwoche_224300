namespace ppedv.HighwayToHell.Model.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Car> CarRepository { get; }
        IRepository<Order> OrderRepository { get; }
        //... repos

        int SaveChanges();

        IRepository<T> GetRepo<T>() where T : Entity;
    }

    public interface IRepository<T> where T : Entity
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
