namespace ppedv.HighwayToHell.Model
{
    public class Car : Entity
    {
        public string Model { get; set; } = string.Empty;
        public virtual Manufacturer? Manufacturer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual ICollection<CarType> CarTypes { get; set; } = new HashSet<CarType>();
    }
}