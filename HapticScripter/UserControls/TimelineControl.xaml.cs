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
            ((AppViewModel)this.DataContext).TimelineControlViewModel.HeaderWidth = 1000;



            BindingList<HapticEvent> blah = new BindingList<HapticEvent>();
            blah.Add(new HapticEvent());
            ((AppViewModel)this.DataContext).DataViewModel.TopAxisData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.BothAxisData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.BottomAxisData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.SqueezeAxisData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.TopPeriodicData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.BothPeriodicData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.BottomPeriodicData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.SqueezePeriodicData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.LubeAxisData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.HeatAxisData = blah;
            ((AppViewModel)this.DataContext).DataViewModel.StopAxisData = blah;
        }
    }
}
