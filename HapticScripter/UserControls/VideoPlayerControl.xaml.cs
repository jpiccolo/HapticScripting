namespace HapticScripter.UserControls
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    using HapticScripter.Data;
    using HapticScripter.ViewModel;

    /// <summary>
	/// Interaction logic for VideoPlayerControl.xaml
	/// </summary>
	public partial class VideoPlayerControl : UserControl
    {
		public VideoPlayerControl()
		{
			this.InitializeComponent();
		}

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

        
        public void LoadVideo()
        {
            this.VideoPlayer.BeginInit();
            var uri = new Uri(@"C:\a.wmv", UriKind.RelativeOrAbsolute);
            this.VideoPlayer.Source = uri;

            var MediaTimeLine = new MediaTimeline(uri);
            
            MediaTimeLine.CurrentTimeInvalidated += this.PositionChanged;
            MediaTimeLine.CurrentGlobalSpeedInvalidated += SpeedRatioChanged;

            VideoPlayer.Clock = MediaTimeLine.CreateClock(true) as MediaClock;
            
            VideoPlayer.Clock.Controller.Stop();

            this.VideoPlayer.LoadedBehavior = MediaState.Manual;
            this.VideoPlayer.UnloadedBehavior = MediaState.Manual;
            this.VideoPlayer.MediaOpened += delegate
            {
                ((VideoPlayerControlViewModel)this.VideoPlayer.DataContext).Duration = VideoPlayer.Clock.NaturalDuration.TimeSpan;
                //VideoSlider.Maximum =
                //    WMPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                //mre.Set();
            };

            this.VideoPlayer.EndInit();
            this.VideoPlayer.Stop();

            ((VideoPlayerControlViewModel)this.VideoPlayer.DataContext).SpeedRatio = VideoPlayer.Clock.Controller.SpeedRatio;
        }

        private void SpeedRatioChanged(object sender, EventArgs e)
        {
            ((VideoPlayerControlViewModel)this.VideoPlayer.DataContext).SpeedRatio = VideoPlayer.Clock.Controller.SpeedRatio;
        }

        private void PositionChanged(object sender, EventArgs e)
        {
            ((VideoPlayerControlViewModel)this.VideoPlayer.DataContext).Position = VideoPlayer.Clock.CurrentTime.Value;
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