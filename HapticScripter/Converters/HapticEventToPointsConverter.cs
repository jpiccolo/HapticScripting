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
            pc.Add(new Point(10, 255));
            pc.Add(new Point(500, 255));
            pc.Add(new Point(500, 200));
            pc.Add(new Point(400, 150));
            pc.Add(new Point(200, 150));
            pc.Add(new Point(10, 200));
            return pc;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) { throw new NotImplementedException(); }
    }
}
