using System;
using System.Windows.Input;

namespace WpfApplication.ViewModel.Commands
{
    public class SearchNeighborhoodCommand : ICommand
    {
        public FindNeighborhoodViewModel SearchNeighborhoodViewModel { get; set; }
        public SearchNeighborhoodCommand(FindNeighborhoodViewModel searchNeighborhoodViewModel)
        {
            SearchNeighborhoodViewModel = searchNeighborhoodViewModel;
        }        

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SearchNeighborhoodViewModel.GetNeighborhood();
        }
    }
}
