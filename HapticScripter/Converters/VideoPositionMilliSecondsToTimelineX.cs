using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Converters
{
    using System.Globalization;
    using System.Windows.Data;

    using HapticScripter.ViewModel;

    public class VideoPositionMilliSecondsToTimelineX : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var localValue = (double)value;
            if (localValue == 0.0)
            {
                return 0;
            }

            double blah = ((localValue/2) - (AppViewModel.TimelineControlViewModel.TimelineScrollViewerViewportWidth / 2));
            return blah;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }

        #endregion
    }
}
