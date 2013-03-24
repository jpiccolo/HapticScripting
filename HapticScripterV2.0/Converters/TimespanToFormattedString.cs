using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.Converters
{
    using System.Globalization;
    using System.Windows.Data;

    public class TimespanToFormattedString : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return "00:00:00.000";
            try
            {
                return ((TimeSpan)value).ToString(@"hh\:mm\:ss\.fff");
            }
            catch (Exception)
            {
                return "00:00:00.000";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }

        #endregion
    }
}
