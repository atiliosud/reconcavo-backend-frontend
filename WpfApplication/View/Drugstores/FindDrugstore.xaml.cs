using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication.Models;
using WpfApplication.View.Neighborhoods;
using WpfApplication.ViewModel;
using WpfApplication.ViewModel.Service;

namespace WpfApplication.View.Drugstores
{
    /// <summary>
    /// Interaction logic for FindDrugstore.xaml
    /// </summary>
    public partial class FindDrugstore : Window
    {
        public FindDrugstore()
        {
            InitializeComponent();
        }

        private void FindNeighorhood_Click(object sender, RoutedEventArgs e)
        {
            FindNeighborhood findNeighborhood = new FindNeighborhood();
            findNeighborhood.ShowDialog();
        }

        private void btnNewDrugstore_Click(object sender, RoutedEventArgs e)
        {
            InsertDrugstore insertDrugstore = new InsertDrugstore();
            insertDrugstore.ShowDialog();
        }

        private void FindDrugstoreByNeighorhood_Click(object sender, RoutedEventArgs e)
        {
            FindDrugstoreByNeighorhood findDrugstoreByNeighorhood = new FindDrugstoreByNeighorhood();
            findDrugstoreByNeighorhood.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = (gridNeighorhood.SelectedItem as DrugStore).Id;            
            UpdateDrugstore updateDrugstore = new UpdateDrugstore(id);            
            updateDrugstore.ShowDialog();            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (gridNeighorhood.SelectedItem as DrugStore).Id;
            DrugStoreService.Delete(new DrugStore() { Id = id });
        }
    }
}
