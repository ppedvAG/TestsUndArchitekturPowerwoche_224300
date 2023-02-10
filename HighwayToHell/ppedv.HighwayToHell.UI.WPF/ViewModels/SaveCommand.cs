using ppedv.HighwayToHell.Model.Contracts;
using System;
using System.Windows.Input;

namespace ppedv.HighwayToHell.UI.WPF.ViewModels
{
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
