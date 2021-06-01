using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace WpfApplication.ViewModel.Converters
{
    public class DrugstoresRoundTheClockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool roundTheClock = (bool)value;

            return roundTheClock == true ? "Sim" : "Não";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string roundTheClock = (string)value;

            return roundTheClock ==  "Sim" ? true : false;
        }
    }
}
