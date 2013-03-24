namespace HapticScripterV2._0.Converters
{
    #region

    using System;
    using System.Globalization;
    using System.Windows.Data;

    #endregion

    public class SpeedRatioToFormattedString : IValueConverter
    {
        #region Public Methods and Operators

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) { return string.Format("x{0}", Math.Truncate(((double)value) * 100) / 100); }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }

        #endregion
    }
}