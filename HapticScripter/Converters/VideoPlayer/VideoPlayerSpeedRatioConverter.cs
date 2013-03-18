using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Converters.VideoPlayer
{
    using System.Globalization;
    using System.Windows.Data;

    public class VideoPlayerSpeedRatioConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) { return string.Format("x{0}", Math.Truncate(((double)value) * 100) / 100); }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }

        #endregion
    }
}
