using System;
using System.Windows.Input;

namespace WpfApplication.ViewModel.Commands.DrugStore
{
    public class FindDrugstoreByNeighorhoodCommand : ICommand
    {
        public FindDrugstoreByNeighorhoodViewModel FindDrugstoreByNeighorhoodViewModel { get; set; }
        public FindDrugstoreByNeighorhoodCommand(FindDrugstoreByNeighorhoodViewModel findDrugstoreByNeighorhoodViewModel)
        {
            FindDrugstoreByNeighorhoodViewModel = findDrugstoreByNeighorhoodViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FindDrugstoreByNeighorhoodViewModel.GetDrugstoresByNeighborhood();
        }
    }
}