namespace HapticScripter
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    using HapticScripter.Data;
    using HapticScripter.UI;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HeaderVisualHost VisualHost { get { return (HeaderVisualHost)this.GetValue(HeaderDrawingVisualProperty); } set { this.SetValue(HeaderDrawingVisualProperty, value); } }

        public static readonly DependencyProperty TopVectorData = DependencyProperty.Register("TopVectorData", typeof(ObservableCollection<HapticEvent>), typeof(MainWindow));
        public static readonly DependencyProperty HeaderDrawingVisualProperty = DependencyProperty.Register("HeaderDrawingVisual", typeof(HeaderVisualHost), typeof(MainWindow));



        public MainWindow()
        {
            InitializeComponent();

            var data = new ObservableCollection<HapticEvent>();

            data.Add(new HapticEvent());

            KeyBindings.VideoBackwardCommand.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt));
            this.CommandBindings.Add(new CommandBinding(KeyBindings.VideoBackwardCommand, this.vi.BackwardButton_Click));
            
            KeyBindings.VideoPlayCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
            this.CommandBindings.Add(new CommandBinding(KeyBindings.VideoPlayCommand, this.VideoPlayerControl.PlayButton_Click));

            KeyBindings.VideoForwardCommand.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Alt));
            this.CommandBindings.Add(new CommandBinding(KeyBindings.VideoForwardCommand, this.VideoPlayerControl.ForwardButton_Click));

            this.SetValue(TopVectorData, data);
            this.DataContext = this;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            


            //Header.Width = 1000;
            //VisualHost = new HeaderVisualHost((int)this.Header.Width, ViewLevel.Level1);


        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if (e.NewValue < 0.60)
            //{
            //    VisualHost = new HeaderVisualHost((int)this.Header.Width, ViewLevel.Level3);
            //}
            //if(e.NewValue < 0.75)
            //{
            //    VisualHost = new HeaderVisualHost((int)this.Header.Width, ViewLevel.Level2);
            //}
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
