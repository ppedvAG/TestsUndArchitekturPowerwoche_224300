namespace ppedv.HighwayToHell.Model
{
    public class OrderItem : Entity
    {
        public int Amount { get; set; }
        public string Color { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public virtual Car? Car { get; set; }
        public virtual Order? Order { get; set; }
    }
}