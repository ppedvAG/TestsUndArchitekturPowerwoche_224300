using Microsoft.EntityFrameworkCore;
using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;

namespace ppedv.HighwayToHell.Data.EfCore
{
    public class EfCarRepository : EfRepository<Car>, ICarRepository
    {
        public EfCarRepository(EfContext context) : base(context)
        { }

        public IEnumerable<Car> GetAllCarsFromTheNiceStoredProcedure()
        {
            return _context.Database.SqlQueryRaw<Car>("exec SP_Cars");
        }
    }
}
