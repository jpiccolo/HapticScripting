namespace HapticScripter.UserControls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    using HapticScripter.Data;

    /// <summary>
	/// Interaction logic for VideoPlayerControl.xaml
	/// </summary>
	public partial class VideoPlayerControlModel : UserControl
    {
		public VideoPlayerControlModel()
		{
			this.InitializeComponent();

		    this.DataContext = this;
		}

        private bool videoPaused = true;
        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            //Is Active
            if (VideoPlayer.Clock.CurrentState == ClockState.Active)
            {
                //Is Paused
                if (VideoPlayer.Clock.CurrentGlobalSpeed == 0.0)
                    VideoPlayer.Clock.Controller.Resume();
                else //Is Playing
                    VideoPlayer.Clock.Controller.Pause();
            }
            else if (VideoPlayer.Clock.CurrentState == ClockState.Stopped) //Is Stopped
                VideoPlayer.Clock.Controller.Begin();
        }

        private MediaTimeline MediaTimeLine;

        public void LoadVideo()
        {
            this.VideoPlayer.BeginInit();
            var uri = new Uri(@"C:\a.wmv", UriKind.RelativeOrAbsolute);
            this.VideoPlayer.Source = uri;

            MediaTimeLine = new MediaTimeline(uri);
            MediaTimeLine.CurrentTimeInvalidated += new EventHandler(MTimeline_CurrentTimeInvalidated);
            VideoPlayer.Clock = MediaTimeLine.CreateClock(true) as MediaClock;
            VideoPlayer.Clock.Controller.Stop();

            this.VideoPlayer.LoadedBehavior = MediaState.Manual;
            this.VideoPlayer.UnloadedBehavior = MediaState.Manual;
            this.VideoPlayer.MediaOpened += delegate
            {
                //VideoSlider.Maximum =
                //    WMPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                //mre.Set();
            };

            this.VideoPlayer.EndInit();
            this.VideoPlayer.Stop();
            //Duration = "kdnf";
            //Duration = VideoPlayer.NaturalDuration.TimeSpan.ToString();
        }

        private void MTimeline_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            Console.WriteLine(VideoPlayer.Clock.CurrentTime.Value.TotalSeconds);

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.VideoPlayer.Visibility = Visibility.Visible;

            this.LoadVideo();
        }

        public void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (VideoPlayer.Clock.CurrentState == ClockState.Active)
            {
                if (VideoPlayer.Clock.CurrentGlobalSpeed == 0.0)
                {
                    VideoPlayer.Clock.Controller.Seek(
                        (VideoPlayer.Clock.CurrentTime.Value - TimeSpan.FromMilliseconds(33.33)), TimeSeekOrigin.BeginTime);
                    VideoPlayer.Clock.Controller.Pause();
                    return;
                }

                if (VideoPlayer.Clock.Controller.SpeedRatio >= 0.11)
                {
                    VideoPlayer.Clock.Controller.SpeedRatio = (VideoPlayer.Clock.Controller.SpeedRatio - 0.1);
                }
            }
        }

        public void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            if (VideoPlayer.Clock.CurrentState == ClockState.Active)
            {
                if (VideoPlayer.Clock.CurrentGlobalSpeed == 0.0)
                {
                    VideoPlayer.Clock.Controller.Seek(
                        (VideoPlayer.Clock.CurrentTime.Value + TimeSpan.FromMilliseconds(33.33)), TimeSeekOrigin.BeginTime);
                    VideoPlayer.Clock.Controller.Pause();
                    return;
                }

                if (VideoPlayer.Clock.Controller.SpeedRatio <= 8)
                {
                    VideoPlayer.Clock.Controller.SpeedRatio = (VideoPlayer.Clock.Controller.SpeedRatio + 0.1);
                }
            }
        }
	}
}