using System.Collections.Generic;
using System.ComponentModel;
using WpfApplication.Models;
using WpfApplication.ViewModel.Commands.DrugStore;
using WpfApplication.ViewModel.Service;

namespace WpfApplication.ViewModel
{
    public class FindDrugstoreViewModel : INotifyPropertyChanged
    {
        public FindDrugstoreCommand FindDrugstoreCommand { get; set; }
        public FindDrugstoreViewModel()
        {
            FindDrugstoreCommand = new FindDrugstoreCommand(this);
            this.SizeSearch = 10;
            GetDrugstores();
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

        private string drugstoreSearch = "";
        public string DrugstoreSearch
        {
            get { return drugstoreSearch; }
            set
            {
                drugstoreSearch = value;
                OnPropertyChanged("DrugstoreSearch");
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

        public async void GetDrugstores()
        {
            this.Drugstores = await DrugStoreService.Get(sizeSearch, DrugstoreSearch);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
