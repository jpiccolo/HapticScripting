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
	/// <summary>
	/// Interaction logic for VideoPlayerControl.xaml
	/// </summary>
	public partial class VideoPlayerControl : UserControl
	{
        
		public VideoPlayerControl()
		{
			this.InitializeComponent();
		}

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            
            if ((string)this.PlayButton.Content == "Pause")
            {
                VideoPlayer.Pause();
                //wmpTimer.Stop();
                PlayButton.Content = "Play";
            }
            else
            {
                VideoPlayer.Play();
                //wmpTimer.Start();
                PlayButton.Content = "Pause";
            }
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
        }
	}
}