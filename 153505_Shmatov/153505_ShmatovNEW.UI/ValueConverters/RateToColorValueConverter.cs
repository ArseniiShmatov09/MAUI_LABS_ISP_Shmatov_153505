using System.Globalization;

namespace _153505_ShmatovNEW.UI.ValueConverters
{
    internal class RateToColorValueConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,CultureInfo culture)
        {
            if ((double)value < 5)
                return Colors.LemonChiffon;
            return Colors.WhiteSmoke;

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
