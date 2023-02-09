namespace ppedv.HighwayToHell.Model
{
    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public virtual ICollection<Order> BillingOrder { get; set; } = new HashSet<Order>();
        public virtual ICollection<Order> DeliveryOrder { get; set; } = new HashSet<Order>();
    }
}