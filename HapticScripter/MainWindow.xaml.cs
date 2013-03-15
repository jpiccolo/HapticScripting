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

namespace HapticScripter
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using HapticScripter.Data;
    using HapticScripter.UI;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HeaderVisualHost VisualHost { get { return (HeaderVisualHost)GetValue(HeaderDrawingVisualProperty); } set { SetValue(HeaderDrawingVisualProperty, value); } }

        public static readonly DependencyProperty TopVectorData = DependencyProperty.Register("TopVectorData", typeof(ObservableCollection<HapticEvent>), typeof(MainWindow));
        public static readonly DependencyProperty HeaderDrawingVisualProperty = DependencyProperty.Register("HeaderDrawingVisual", typeof(HeaderVisualHost), typeof(MainWindow));



        public enum ViewLevel
        {
            Level1 = 10,
            Level2 = 20,
            Level3 = 30,
            Level4 = 40,
            Level5 = 50
        }

        public MainWindow()
        {
            InitializeComponent();

            var data = new ObservableCollection<HapticEvent>();

            data.Add(new HapticEvent());

            
            KeyBindings.MyCommands.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
            CommandBindings.Add(new CommandBinding(KeyBindings.MyCommands, this.Button_Click));

            this.SetValue(TopVectorData, data);
            this.DataContext = this;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            


            Header.Width = 1000;
            VisualHost = new HeaderVisualHost((int)this.Header.Width, ViewLevel.Level1);


        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue < 0.60)
            {
                VisualHost = new HeaderVisualHost((int)this.Header.Width, ViewLevel.Level3);
            }
            if(e.NewValue < 0.75)
            {
                VisualHost = new HeaderVisualHost((int)this.Header.Width, ViewLevel.Level2);
            }
        }

        private void speedRation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            //VideoPlayer.SpeedRatio = (double)speedRation.Value;
            //mre.WaitOne(5000);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
