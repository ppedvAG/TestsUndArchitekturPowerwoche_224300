using FluentAssertions;
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

            result.Should().BeTrue();
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
                result.Should().Be(1);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.OrderItems.Find(oi.Id);
                loaded.Should().NotBeNull().And.BeEquivalentTo(oi);
            }
        }
    }
}