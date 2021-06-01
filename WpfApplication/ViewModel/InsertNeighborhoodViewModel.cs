using System.ComponentModel;
using WpfApplication.Models;
using WpfApplication.ViewModel.Commands;
using WpfApplication.ViewModel.Service;

namespace WpfApplication.ViewModel
{
    public class InsertNeighborhoodViewModel : INotifyPropertyChanged
    {
        public InsertNeighborhoodViewModel()
        {            
            InsertNeighborhoodCommand = new InsertNeighborhoodCommand(this);
        }

        private string neighborhoodInsert;
        public string NeighborhoodInsert
        {
            get { return neighborhoodInsert; }
            set
            {
                neighborhoodInsert = value;
                OnPropertyChanged("NeighborhoodInsert");
            }
        }

        public InsertNeighborhoodCommand InsertNeighborhoodCommand { get; set; }
     

        public async void PostNeighborhood()
        {
            var neighborhood = new Neighborhood() { Name = NeighborhoodInsert };
            var result = await NeighborhoodService.Post(neighborhood);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
