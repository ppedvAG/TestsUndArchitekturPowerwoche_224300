using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

namespace ppedv.HighwayToHell.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        readonly EfContext _context;

        public EfUnitOfWork(string conString)
        {
            _context = new EfContext(conString);
        }

        public IRepository<Car> CarRepository => new EfRepository<Car>(_context);

        public IRepository<Order> OrderRepository => new EfRepository<Order>(_context);

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfRepository<T>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly EfContext _context;

        public EfRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
