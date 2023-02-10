using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ppedv.HighwayToHell.UI.WPF.ViewModels
{
    public class CustomerViewModel : ObservableObject
    {
        private CustomerItemViewModel selectedCustomer;
        public ICommand SaveCommand { get; set; }
        public ICommand SaveCommand2 { get; set; }

        public CustomerViewModel(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            foreach (var item in unitOfWork.GetRepo<Customer>().GetAll())
            {
                CustomerList.Add(new CustomerItemViewModel(item)
                {
                    CarCount = "12",
                    Steuernummer = "382764876"
                });
            }

            SaveCommand = new SaveCommand(UnitOfWork);
            SaveCommand2 = new RelayCommand(() => unitOfWork.SaveChanges());
        }

        public IUnitOfWork UnitOfWork { get; }

        public ObservableCollection<CustomerItemViewModel> CustomerList { get; set; } = new ObservableCollection<CustomerItemViewModel>();

        public CustomerItemViewModel SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
                OnPropertyChanged(nameof(CarCountOfSelectedCustomer));
                //PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(SelectedCustomer)));
                //PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(CarCountOfSelectedCustomer)));
            }
        }

        public int CarCountOfSelectedCustomer
        {
            get
            {
                if (SelectedCustomer == null)
                    return -1;

                return DateAndTime.Now.Second;
            }
        }

    }
}
