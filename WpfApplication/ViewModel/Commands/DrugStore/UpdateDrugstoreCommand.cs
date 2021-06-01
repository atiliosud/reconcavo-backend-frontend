using System;
using System.Windows.Input;

namespace WpfApplication.ViewModel.Commands.DrugStore
{
    public class UpdateDrugstoreCommand : ICommand
    {
        public UpdateDrugstoreViewModel UpdateDrugstoreViewModel { get; set; }
        public UpdateDrugstoreCommand(UpdateDrugstoreViewModel insertDrugstoreViewModel)
        {
            UpdateDrugstoreViewModel = insertDrugstoreViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            UpdateDrugstoreViewModel.PutDrugStore();
        }
    }
}