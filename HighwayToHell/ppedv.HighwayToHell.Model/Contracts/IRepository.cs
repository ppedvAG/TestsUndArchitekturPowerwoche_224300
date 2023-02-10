namespace ppedv.HighwayToHell.Model.Contracts
{

    public interface IRepository<T> where T : Entity
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
