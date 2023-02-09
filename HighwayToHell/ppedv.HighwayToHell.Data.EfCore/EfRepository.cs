using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

namespace ppedv.HighwayToHell.Data.EfCore
{
    public class EfRepository : IRepository
    {
        readonly EfContext _context;

        public EfRepository(string conString)
        {
            _context = new EfContext(conString);
        }

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T).IsAssignableFrom(typeof(Car)))
            //    _context.Cars.Add(entity as Car);
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }
    }
}
