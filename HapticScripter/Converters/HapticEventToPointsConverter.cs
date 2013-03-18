using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Converters
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;

    public class HapticEventToPointsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var pc = new PointCollection();
            pc.Add(new Point(49, 23));
            pc.Add(new Point(100, 23));
            pc.Add(new Point(100, 14));
            pc.Add(new Point(95, 5));
            pc.Add(new Point(55, 5));
            pc.Add(new Point(49, 14));
            return pc;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) { throw new NotImplementedException(); }
    }
}
