using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.HighwayToHell.Model;
using System.Reflection;

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

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_update_OrderItem()
        {
            var oi = new OrderItem() { Amount = 1, Color = $"gelb_{Guid.NewGuid()}", Price = 5.50m };
            var newColor = $"blau_{Guid.NewGuid()}";
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.OrderItems.Add(oi);
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext(conString)) //UPDATE
            {
                var loaded = con.OrderItems.Find(oi.Id);
                loaded.Color = newColor;
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.OrderItems.Find(oi.Id);
                loaded.Color.Should().Be(newColor);
            }
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_delete_OrderItem()
        {
            var oi = new OrderItem() { Amount = 1, Color = $"gelb_{Guid.NewGuid()}", Price = 5.50m };
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.OrderItems.Add(oi);
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext(conString)) //DELETE
            {
                var loaded = con.OrderItems.Find(oi.Id);
                con.OrderItems.Remove(loaded);
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.OrderItems.Find(oi.Id);
                loaded.Should().BeNull();
            }
        }


        [Fact]
        [Trait("Category", "Integration")]
        public void Can_create_OrderItem_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));
            var oi = fix.Create<OrderItem>();

            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();

                con.OrderItems.Add(oi);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.OrderItems.Find(oi.Id);
                loaded.Should().NotBeNull().And.BeEquivalentTo(oi, x => x.IgnoringCyclicReferences());
            }
        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}