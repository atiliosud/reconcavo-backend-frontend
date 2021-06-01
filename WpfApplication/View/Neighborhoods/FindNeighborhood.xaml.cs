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

namespace WpfApplication.View.Neighborhoods
{
    /// <summary>
    /// Interaction logic for FindNeighborhood.xaml
    /// </summary>
    public partial class FindNeighborhood : Window
    {
        public FindNeighborhood()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewNeighorhood_Click(object sender, RoutedEventArgs e)
        {
            InsertNeighborhood insertNeighborhoodPage = new InsertNeighborhood();
            insertNeighborhoodPage.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
