namespace ppedv.HighwayToHell.Model
{
    public class CarType : Entity
    {
        public string TypeName { get; set; } = string.Empty;
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}