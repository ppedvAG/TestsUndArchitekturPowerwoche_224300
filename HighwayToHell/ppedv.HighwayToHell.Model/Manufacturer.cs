namespace ppedv.HighwayToHell.Model
{
    public class Manufacturer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}