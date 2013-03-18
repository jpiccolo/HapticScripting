using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Converters.VideoPlayer
{
    using System.Globalization;
    using System.Windows.Data;

    public class VideoPlayerTimeSpanToDisplayConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan incoming = (TimeSpan)value;

            return incoming.ToString(@"hh\:mm\:ss\.fff");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }

        #endregion
    }
}
