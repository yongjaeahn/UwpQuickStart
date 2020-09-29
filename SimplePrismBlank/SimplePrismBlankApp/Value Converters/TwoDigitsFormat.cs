// Value Converters\TwoDigitsFormat.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SimplePrismBlankApp.Value_Converters
{
    class TwoDigitsFormat : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            return String.Format("{0:00}",(int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            return value;
        }
    }
}
