using System;
using System.Windows.Input;

namespace WpfApplication.ViewModel.Commands.DrugStore
{
    public class CallUpdateCommand : ICommand
    {
        public FindDrugstoreViewModel FindDrugstoreViewModel { get; set; }
        public CallUpdateCommand(FindDrugstoreViewModel findDrugstoreViewModel)
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
            //FindDrugstoreViewModel.PutDrugStore((int)parameter);
        }
    }
}