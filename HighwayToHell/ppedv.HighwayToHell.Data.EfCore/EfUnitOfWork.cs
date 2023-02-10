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

        public ICarRepository CarRepository => new EfCarRepository(_context);

        public IRepository<Order> OrderRepository => new EfRepository<Order>(_context);

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            //if (typeof(T) == typeof(Car))
                //return new EfCarRepository(_context) as IRepository<Car>;

            return new EfRepository<T>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
