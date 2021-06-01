using System;
using System.Windows.Input;

namespace WpfApplication.ViewModel.Commands.DrugStore
{
    public class FindDrugstoreCommand : ICommand
    {
        public FindDrugstoreViewModel FindDrugstoreViewModel { get; set; }
        public FindDrugstoreCommand(FindDrugstoreViewModel findDrugstoreViewModel)
        {
            FindDrugstoreViewModel = findDrugstoreViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FindDrugstoreViewModel.GetDrugstores();
        }
    }
}