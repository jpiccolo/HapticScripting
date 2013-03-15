using System;
using System.Collections.Generic;
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
    using HapticScripter.Data;
    using HapticScripter.UI;

    /// <summary>
	/// Interaction logic for VideoPlayerControl.xaml
	/// </summary>
	public partial class VideoPlayerControl : UserControl
    {
        public VideoPlayerDataModel model;
		public VideoPlayerControl()
		{
			this.InitializeComponent();

            model = new VideoPlayerDataModel();

		    this.DataContext = model;
		}

        private bool videoPaused = true;
        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!videoPaused)
            {
                VideoPlayer.Pause();
                videoPaused = true;
            }
            else
            {
                VideoPlayer.Play();
                videoPaused = false;
            }
            e.Handled = true;
        }

        public void LoadVideo()
        {
            VideoPlayer.BeginInit();
            VideoPlayer.Source = new Uri(@"C:\a.wmv", UriKind.RelativeOrAbsolute);

            VideoPlayer.LoadedBehavior = VideoPlayer.UnloadedBehavior = MediaState.Manual;
            VideoPlayer.MediaOpened += delegate
            {
                //VideoSlider.Maximum =
                //    WMPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                //mre.Set();
            };

            VideoPlayer.EndInit();
            VideoPlayer.Stop();

            //model.Duration = VideoPlayer.NaturalDuration.TimeSpan.ToString();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Visibility = Visibility.Visible;

            this.LoadVideo();
        }

        public void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (videoPaused)
            {
                VideoPlayer.Position = VideoPlayer.Position - TimeSpan.FromMilliseconds(33.33);
                return;
            }

            VideoPlayer.SpeedRatio = (VideoPlayer.SpeedRatio - 0.01);
        }

        public void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            if (videoPaused)
            {
                VideoPlayer.Position = VideoPlayer.Position + TimeSpan.FromMilliseconds(33.33);
                return;
            }

            VideoPlayer.SpeedRatio++;
        }
	}
}