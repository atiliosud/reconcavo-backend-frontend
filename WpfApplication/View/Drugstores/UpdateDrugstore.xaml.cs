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
using WpfApplication.ViewModel;
using WpfApplication.ViewModel.Service;

namespace WpfApplication.View.Drugstores
{
    /// <summary>
    /// Interaction logic for UpdateDrugstore.xaml
    /// </summary>
    public partial class UpdateDrugstore : Window
    {
        int Id;
        public UpdateDrugstore(int id)
        {
            InitializeComponent();
            Set(id);
        }

        private async void Set(int id)
        {
            var drugstore = await DrugStoreService.GetById(id);
            cbNeighborhood.SelectedIndex = drugstore.id_neighborhood;
            ck24.IsChecked = drugstore.flg_round_the_clock;
            txtName.Text = drugstore.Name;
            txtId.Text = drugstore.Id.ToString();
            dtDate.SelectedDate = drugstore.foundation_date;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
        }
    }
}
