using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using WpfApplication.Models;
using WpfApplication.ViewModel.Commands.DrugStore;
using WpfApplication.ViewModel.Service;

namespace WpfApplication.ViewModel
{
    public class UpdateDrugstoreViewModel : INotifyPropertyChanged
    {
        public UpdateDrugstoreCommand UpdateDrugstoreCommand { get; set; }

        public UpdateDrugstoreViewModel()
        {
            UpdateDrugstoreCommand = new UpdateDrugstoreCommand(this);
            GetNeighborhood();
            FoundationDate = DateTime.Now.Date;
        }
        public UpdateDrugstoreViewModel(int id)
        {
            
        }

        public async void SetDrugstore(int id)
        {
            var result = await GetById(id);
            FoundationDate = this.Drugstore.foundation_date;
            FlgRoundTheClock = this.Drugstore.flg_round_the_clock;
            Name = this.Drugstore.Name;
            SelectedNeighborhood = new Neighborhood();
            selectedNeighborhood.Id = this.Drugstore.id_neighborhood;
            Id = id;
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

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
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

        private DrugStore drugstore;
        public DrugStore Drugstore
        {
            get { return drugstore; }
            set
            {
                drugstore = value;
                OnPropertyChanged("Drugstore");
            }
        }

        public async void PutDrugStore()
        {          
                var drugStore = new DrugStore()
                {
                    Id = Id,
                    Name = Name,
                    flg_round_the_clock = FlgRoundTheClock,
                    foundation_date = FoundationDate,
                    id_neighborhood = SelectedNeighborhood.Id
                };
                var result = await DrugStoreService.Put(drugStore);
                  
        }
        public async void GetNeighborhood()
        {
            var sizeSearch = 100;
            this.Neighborhoods = await NeighborhoodService.Get("", sizeSearch);
        }

        public async Task<bool> GetById(int id)
        {            
            this.Drugstore = await DrugStoreService.GetById(id);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
