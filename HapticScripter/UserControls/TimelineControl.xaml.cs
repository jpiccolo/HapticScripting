using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HapticScripter.UserControls
{
    using System.ComponentModel;
    using System.Windows.Threading;

    using HapticScripter.Data;
    using HapticScripter.ViewModel;

    /// <summary>
    /// Interaction logic for TimelineControl.xaml
    /// </summary>
    public partial class TimelineControl : UserControl
    {
        public TimelineControl()
        {
            InitializeComponent();
        }

        private void TimelinesUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindingList<HapticEvent> blah = new BindingList<HapticEvent>();
            blah.Add(new HapticEvent());

            AppViewModel.DataViewModel.TopAxisData = blah;
            AppViewModel.DataViewModel.BothAxisData = blah;
            AppViewModel.DataViewModel.BottomAxisData = blah;
            AppViewModel.DataViewModel.SqueezeAxisData = blah;
            AppViewModel.DataViewModel.TopPeriodicData = blah;
            AppViewModel.DataViewModel.BothPeriodicData = blah;
            AppViewModel.DataViewModel.BottomPeriodicData = blah;
            AppViewModel.DataViewModel.SqueezePeriodicData = blah;
            AppViewModel.DataViewModel.LubeAxisData = blah;
            AppViewModel.DataViewModel.HeatAxisData = blah;
            AppViewModel.DataViewModel.StopAxisData = blah;
        }

        private void TimelineScroller_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AppViewModel.TimelineControlViewModel.TimelineScrollViewerViewportWidth = TimelineScroller.ViewportWidth;
        }

        private void Line_LayoutUpdated(object sender, EventArgs e)
        {
            //var d = AppViewModel.VideoPlayerControlViewModel.Position.TotalMilliseconds / 2;
            //d = d - (TimelineScroller.ViewportWidth / 2);
            //TimelineScroller.ScrollToHorizontalOffset(d);
        }
    }
}
