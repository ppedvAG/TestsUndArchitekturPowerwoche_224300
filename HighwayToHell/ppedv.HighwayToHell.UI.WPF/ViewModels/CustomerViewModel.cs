using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using ppedv.HighwayToHell.Model;
using ppedv.HighwayToHell.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Channels;
using System.Windows.Input;

namespace ppedv.HighwayToHell.UI.WPF.ViewModels
{
    public class CustomerViewModel : ObservableObject
    {
        static string conString = "Server=(localdb)\\mssqllocaldb;Database=HightwayToHell_dev;Trusted_Connection=true;";
        private Customer selectedCustomer;

        //hack: kommt weg!!!
        public CustomerViewModel() : this(new Data.EfCore.EfUnitOfWork(conString))
        { }

        public ICommand SaveCommand { get; set; }
        public ICommand SaveCommand2 { get; set; }


        public CustomerViewModel(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            CustomerList = new List<Customer>(unitOfWork.GetRepo<Customer>().GetAll());
            SaveCommand = new SaveCommand(UnitOfWork);

            SaveCommand2 = new RelayCommand(() => unitOfWork.SaveChanges());
        }

        public IUnitOfWork UnitOfWork { get; }

        public List<Customer> CustomerList { get; set; }

        public Customer SelectedCustomer
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

    class CustomerItemViewModel
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string CarCount { get; set; }
        public string Steuernummer { get; set; }
    }


    class SaveCommand : ICommand
    {
        private readonly IUnitOfWork unitOfWork;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            unitOfWork.SaveChanges();
        }

        public SaveCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
