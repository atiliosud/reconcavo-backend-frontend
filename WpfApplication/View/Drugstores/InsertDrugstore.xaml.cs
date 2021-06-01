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

namespace WpfApplication.View.Drugstores
{
    /// <summary>
    /// Interaction logic for InsertDrugstore.xaml
    /// </summary>
    public partial class InsertDrugstore : Window
    {
        public InsertDrugstore()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
