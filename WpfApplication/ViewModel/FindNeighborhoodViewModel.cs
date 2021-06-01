using System.Collections.Generic;
using System.ComponentModel;
using WpfApplication.Models;
using WpfApplication.ViewModel.Commands;
using WpfApplication.ViewModel.Service;

namespace WpfApplication.ViewModel
{
    public class FindNeighborhoodViewModel : INotifyPropertyChanged
    {
        public SearchNeighborhoodCommand SearchNeighborhoodCommand { get; set; }
        public FindNeighborhoodViewModel()
        {
            SearchNeighborhoodCommand = new SearchNeighborhoodCommand(this);
            this.SizeSearch = 10;
            GetNeighborhood();            
        }        

        private int sizeSearch;

        public int SizeSearch
        {
            get { return sizeSearch; }
            set
            {
                sizeSearch = value;
                OnPropertyChanged("SizeSearch");
            }
        }

        private string neighborhoodSearch;
        public string NeighborhoodSearch
        {
            get { return neighborhoodSearch; }
            set
            {
                neighborhoodSearch = value;
                OnPropertyChanged("NeighborhoodSearch");
            }
        }

        private List<Neighborhood> neighborhoods;
        public List<Neighborhood> Neighborhoods
        {
            get { return neighborhoods; }
            set
            {
                neighborhoods = value;
                OnPropertyChanged("Neighborhoods");
            }
        }

        public async void GetNeighborhood()
        {
            this.Neighborhoods = await NeighborhoodService.Get(NeighborhoodSearch, sizeSearch);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
