using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.Converters
{
    using System.Globalization;
    using System.Windows.Data;

    using HapticScripterV2._0.ViewModels;

    public class VideoPositionToSliderValue : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimeSpan)value).TotalSeconds / AppViewModel.VideoViewModel.Duration.TotalSeconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
