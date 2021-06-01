using System;
using System.Collections.Generic;
using System.ComponentModel;
using WpfApplication.Models;
using WpfApplication.ViewModel.Commands.DrugStore;
using WpfApplication.ViewModel.Service;

namespace WpfApplication.ViewModel
{
    public class InsertDrugstoreViewModel : INotifyPropertyChanged
    {
        public InsertDrugstoreCommand InsertDrugstoreCommand { get; set; }
        public InsertDrugstoreViewModel()
        {
            InsertDrugstoreCommand = new InsertDrugstoreCommand(this);
            GetNeighborhood();
            FoundationDate = DateTime.Now.Date;
        }
        private List<Neighborhood> neighborhoods ;
        public List<Neighborhood> Neighborhoods
        {
            get { return neighborhoods; }
            set
            {
                neighborhoods = value;
                OnPropertyChanged("Neighborhoods");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
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

        private DateTime foundationDate;
        public DateTime FoundationDate
        {
            get { return foundationDate; }
            set
            {
                foundationDate = value;
                OnPropertyChanged("FoundationDate");
            }
        }

        private int idneighborhood;
        public int IdNeighborhood
        {
            get { return idneighborhood; }
            set
            {
                idneighborhood = value;
                OnPropertyChanged("IdNeighborhood");
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
        

        public async void PostDrugStore()
        {
            var drugStore = new DrugStore() { 
                Name = name, 
                flg_round_the_clock = FlgRoundTheClock,
                foundation_date = FoundationDate,
                id_neighborhood = SelectedNeighborhood.Id
            };
            var result = await DrugStoreService.Post(drugStore);
        }
        public async void GetNeighborhood()
        {
            var sizeSearch = 100;
            this.Neighborhoods = await NeighborhoodService.Get("", sizeSearch);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
