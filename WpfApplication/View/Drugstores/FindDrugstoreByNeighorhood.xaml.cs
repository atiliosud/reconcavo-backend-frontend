using System.Windows;

namespace WpfApplication.View.Drugstores
{
    /// <summary>
    /// Interaction logic for FindDrugstore.xaml
    /// </summary>
    public partial class FindDrugstoreByNeighorhood : Window
    {
        public FindDrugstoreByNeighorhood()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
