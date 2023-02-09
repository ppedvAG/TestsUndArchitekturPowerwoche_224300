namespace ppedv.HighwayToHell.Data.EfCore.Tests
{
    public class EfContextTests
    {
        readonly string conString = "Server=(localdb)\\mssqllocaldb;Database=HightwayToHell_dev;Trusted_Connection=true;";
        
        [Fact]
        public void Can_create_db()
        {
            var con = new EfContext(conString); 
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }
    }
}