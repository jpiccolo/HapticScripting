using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.Converters
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;

    using HapticScripterV2._0.Models;

    public class HapticEventToPointsConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            const double UnitSize = 2.0;

            try
            {
                double height = (double)values[0];
                HapticEvent hapticEvent = (HapticEvent)values[1];

                double startX = hapticEvent.Start / UnitSize;
                double fadeOutX = (hapticEvent.Start + hapticEvent.Duration) / UnitSize;

                Point startp = new Point(startX, height);

                Point end = new Point(fadeOutX, height);

                double perc = Math.Abs(hapticEvent.OutMagnitude / 255.0);

                Point fadeOutMag = new Point(fadeOutX, height - (height * perc));

                perc = Math.Abs(hapticEvent.Magnitude / 255.0);

                double topY = height - (height * perc);
                Point fadeOutStart = new Point(
                    ((hapticEvent.Start + hapticEvent.Duration) - hapticEvent.OutDuration) / UnitSize, topY);

                Point fadeInEnd = new Point((hapticEvent.Start + hapticEvent.InDuration) / UnitSize, topY);

                perc = Math.Abs(hapticEvent.InMagnitude / 255.0);

                Point fadeInMag = new Point(startX, height - (height * perc));

                return new PointCollection { startp, end, fadeOutMag, fadeOutStart, fadeInEnd, fadeInMag };
            }
            catch (Exception)
            {
                return new PointCollection(); 
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) { throw new NotImplementedException(); }

        #endregion
    }
}
