using System.Collections.Generic;
using System.ComponentModel;
using WpfApplication.Models;
using WpfApplication.ViewModel.Commands.DrugStore;
using WpfApplication.ViewModel.Service;

namespace WpfApplication.ViewModel
{
    public class FindDrugstoreByNeighorhoodViewModel : INotifyPropertyChanged
    {
        public FindDrugstoreByNeighorhoodCommand FindDrugstoreByNeighorhoodCommand { get; set; }
        public FindDrugstoreByNeighorhoodViewModel()
        {
            FindDrugstoreByNeighorhoodCommand = new FindDrugstoreByNeighorhoodCommand(this);
            GetNeighborhood();
            GetDrugstores();
        }

        private bool flgRoundTheClock;
        public bool FlgRoundTheClock
        {
            get { return flgRoundTheClock; }
            set
            {
                flgRoundTheClock = value;
                OnPropertyChanged("FlgRoundTheClock");
            }
        }

        private List<DrugStore> drugstores;
        public List<DrugStore> Drugstores
        {
            get { return drugstores; }
            set
            {
                drugstores = value;
                OnPropertyChanged("Drugstores");
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

        private Neighborhood selectedNeighborhood;
        public Neighborhood SelectedNeighborhood
        {
            get { return selectedNeighborhood; }
            set
            {
                selectedNeighborhood = value;
                OnPropertyChanged("SelectedNeighborhood");
            }
        }

        public async void GetNeighborhood()
        {
            var sizeSearch = 100;
            this.Neighborhoods = await NeighborhoodService.Get("", sizeSearch);
        } 

        public async void GetDrugstoresByNeighborhood()
        {
            int id = 0;
            if(SelectedNeighborhood != null)
            {
                id = SelectedNeighborhood.Id;
            }
            this.Drugstores = await DrugStoreService.GetByNeighborhood(id, FlgRoundTheClock);
        }

        public async void GetDrugstores()
        {
            this.Drugstores = await DrugStoreService.Get(10, "");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
