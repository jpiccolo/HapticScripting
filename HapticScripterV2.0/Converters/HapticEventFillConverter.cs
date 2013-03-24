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

    public class HapticEventFillConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)parameter)
            {
                case "tba":
                    if (value.ToString() == "In")
                    {
                        return Application.Current.FindResource("TopBottomAxisIn") as DrawingBrush;
                    }
                    return Application.Current.FindResource("TopBottomAxisOut") as DrawingBrush;

                case "ba":
                    if (value.ToString() == "In")
                    {
                        return Application.Current.FindResource("BothAxisIn") as DrawingBrush;
                    }
                    return Application.Current.FindResource("BothAxisOut") as DrawingBrush;


                case "sa":
                    if (value.ToString() == "In")
                    {
                        return Application.Current.FindResource("SqueezeAxisIn") as DrawingBrush;
                    }
                    return Application.Current.FindResource("SqueezeAxisOut") as DrawingBrush;

                case "ptb":
                    if (value.ToString() == "In")
                    {
                        return Application.Current.FindResource("PeriodicTopBottomAxisIn") as DrawingBrush;
                    }
                    return Application.Current.FindResource("PeriodicTopBottomAxisOut") as DrawingBrush;

                case "pb":
                    if (value.ToString() == "In")
                    {
                        return Application.Current.FindResource("PeriodicBothAxisIn") as DrawingBrush;
                    }
                    return Application.Current.FindResource("PeriodicBothAxisOut") as DrawingBrush;

                case "ps":
                    if (value.ToString() == "In")
                    {
                        return Application.Current.FindResource("PeriodicSqueezeIn") as DrawingBrush;
                    }
                    return Application.Current.FindResource("PeriodicSqueezeOut") as DrawingBrush;

            }

            return new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }

        #endregion
    }
}
