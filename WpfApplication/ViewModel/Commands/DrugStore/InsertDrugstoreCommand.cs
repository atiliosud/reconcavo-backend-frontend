using System;
using System.Windows.Input;

namespace WpfApplication.ViewModel.Commands.DrugStore
{
    public class InsertDrugstoreCommand : ICommand
    {
        public InsertDrugstoreViewModel  InsertDrugstoreViewModel { get; set; }
        public InsertDrugstoreCommand(InsertDrugstoreViewModel insertDrugstoreViewModel)
        {
            InsertDrugstoreViewModel = insertDrugstoreViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InsertDrugstoreViewModel.PostDrugStore();
        }
    }
}