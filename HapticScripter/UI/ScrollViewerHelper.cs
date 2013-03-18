using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.UI
{
    using System.Windows;
    using System.Windows.Controls;

    public static class ScrollViewerHelper
    {
        public static double GetAutoScroll(DependencyObject obj)
        {
            return (double)obj.GetValue(AutoScrollProperty);
        }

        public static void SetAutoScroll(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollProperty, value);
        }

        public static readonly DependencyProperty AutoScrollProperty =
            DependencyProperty.RegisterAttached("AutoScroll", typeof(double), typeof(ScrollViewerHelper), new PropertyMetadata(0.0, AutoScrollPropertyChanged));

        private static void AutoScrollPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = d as ScrollViewer;

            if (scrollViewer != null && (bool)e.NewValue)
            {
                scrollViewer.ScrollToBottom();
            }
        }
    }
}
