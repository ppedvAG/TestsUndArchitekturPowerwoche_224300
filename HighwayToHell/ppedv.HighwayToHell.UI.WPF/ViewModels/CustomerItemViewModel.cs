using ppedv.HighwayToHell.Model;

namespace ppedv.HighwayToHell.UI.WPF.ViewModels
{
    public class CustomerItemViewModel
    {
        private readonly Customer customer;

        public CustomerItemViewModel(Customer customer)
        {
            this.customer = customer;
        }

        public string Name { get => customer.Name; set => customer.Name = value; }
        public string Adress { get => customer.Adress; set => customer.Adress = value; }
        public string CarCount { get; set; }
        public string Steuernummer { get; set; }
    }
}
