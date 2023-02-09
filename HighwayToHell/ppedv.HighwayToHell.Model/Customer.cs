﻿namespace ppedv.HighwayToHell.Model
{
    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public virtual ICollection<Order> BillingOrders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Order> DeliveryOrders { get; set; } = new HashSet<Order>();
    }
}