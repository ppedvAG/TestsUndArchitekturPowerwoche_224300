using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

namespace ppedv.HighwayToHell.Data.EfCore
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly EfContext _context;

        public EfRepository(EfContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
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
