using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Converters
{
    using System.Globalization;
    using System.Windows.Data;

    public class VideoPositionToTimelineX : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var milliSec = ((TimeSpan)value).TotalMilliseconds;
            if (milliSec == 0)
            {
                return 0;
            }
            var d = ((TimeSpan)value).TotalMilliseconds / 2;
            return d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }

        #endregion
    }
}
