using System;
using System.Windows.Input;

namespace WpfApplication.ViewModel.Commands
{
    public class InsertNeighborhoodCommand : ICommand
    {
        public InsertNeighborhoodViewModel NeighborhoodViewModel { get; set; }
        public InsertNeighborhoodCommand(InsertNeighborhoodViewModel neighborhoodViewModel)
        {
            NeighborhoodViewModel = neighborhoodViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NeighborhoodViewModel.PostNeighborhood();
        }
    }
}
