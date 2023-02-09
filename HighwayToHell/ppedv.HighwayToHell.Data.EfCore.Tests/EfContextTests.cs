using ppedv.HighwayToHell.Model;

namespace ppedv.HighwayToHell.Data.EfCore.Tests
{
    public class EfContextTests
    {
        readonly string conString = "Server=(localdb)\\mssqllocaldb;Database=HightwayToHell_dev;Trusted_Connection=true;";

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_create_db()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_create_OrderItem()
        {
            var oi = new OrderItem() { Amount = 1, Color = $"gelb_{Guid.NewGuid()}", Price = 5.50m };
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();

                con.OrderItems.Add(oi);
                var result = con.SaveChanges();
                Assert.Equal(1, result);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.OrderItems.Find(oi.Id);
                Assert.NotNull(loaded);
                Assert.Equal(oi.Amount, loaded.Amount);
                Assert.Equal(oi.Color, loaded.Color);
                Assert.Equal(oi.Price, loaded.Price);
            }
        }
    }
}