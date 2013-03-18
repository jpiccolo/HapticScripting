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
            var clock = this.VideoPlayer.Clock;
            if (clock == null)
            {
                return;
            }
            //Is Active
            switch (this.VideoPlayer.Clock.CurrentState)
            {
                case ClockState.Active:

                    if (this.VideoPlayer.Clock.CurrentGlobalSpeed == 0.0)
                    {
                        if (clock.Controller != null)
                        {
                            clock.Controller.Resume();
                        }
                    }
                    else //Is Playing
                    {
                        var clockController = this.VideoPlayer.Clock.Controller;
                        if (clockController != null)
                        {
                            clockController.Pause();
                        }
                    }

                    break;
                case ClockState.Stopped:
                    var controller = this.VideoPlayer.Clock.Controller;
                    if (controller != null)
                    {
                        controller.Begin();
                    }
                    break;
            }
        }

        public void LoadVideo()
        {
            this.VideoPlayer.BeginInit();
            var uri = new Uri(@"C:\a.wmv", UriKind.RelativeOrAbsolute);
            this.VideoPlayer.Source = uri;

            var mediaTimeLine = new MediaTimeline(uri);
            
            mediaTimeLine.CurrentTimeInvalidated += this.PositionChanged;
            mediaTimeLine.CurrentGlobalSpeedInvalidated += SpeedRatioChanged;

            VideoPlayer.Clock = mediaTimeLine.CreateClock(true) as MediaClock;

            var mediaClock = this.VideoPlayer.Clock;
            if (mediaClock != null)
            {
                if (mediaClock.Controller != null)
                {
                    mediaClock.Controller.Stop();
                }
            }

            this.VideoPlayer.LoadedBehavior = MediaState.Manual;
            this.VideoPlayer.UnloadedBehavior = MediaState.Manual;
            this.VideoPlayer.MediaOpened += delegate
                                                {
                                                    AppViewModel.VideoPlayerControlViewModel.Duration =
                                                        VideoPlayer.Clock.NaturalDuration.TimeSpan;
                                                    //VideoSlider.Maximum =
                                                    //    WMPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                                                    //mre.Set();
                                                };

            this.VideoPlayer.EndInit();
            this.VideoPlayer.Stop();

            var clockController = this.VideoPlayer.Clock.Controller;
            if (clockController != null)
            {
                AppViewModel.VideoPlayerControlViewModel.SpeedRatio = clockController.SpeedRatio;
            }
        }

        private void SpeedRatioChanged(object sender, EventArgs e)
        {
            var clockController = this.VideoPlayer.Clock.Controller;
            if (clockController != null)
            {
                AppViewModel.VideoPlayerControlViewModel.SpeedRatio = clockController.SpeedRatio;
            }
        }

        private int updateCount;

        private void PositionChanged(object sender, EventArgs e)
        {
            if (this.VideoPlayer.Clock.CurrentState != ClockState.Active)
            {
                return;
            }

            var currentTime = this.VideoPlayer.Clock.CurrentTime;
            if (currentTime != null)
            {
                //if (this.VideoPlayer.Clock.CurrentGlobalSpeed == 0.0)
                //{
                updateCount++;
                if (updateCount > 10)
                {
                    Console.WriteLine(DateTime.Now.TimeOfDay);
                    AppViewModel.VideoPlayerControlViewModel.Position = currentTime.Value;
                    updateCount = 0;
                }

                //}
                //else
                //{
                //    updateCount++;
                //    if (updateCount > 10)
                //    {
                //        AppViewModel.VideoPlayerControlViewModel.Position = currentTime.Value;
                //        updateCount = 0;
                //    }
                //}
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.VideoPlayer.Visibility = Visibility.Visible;

            //this.LoadVideo();
        }

        public void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (this.VideoPlayer.Clock.CurrentState != ClockState.Active)
            {
                return;
            }
            if (this.VideoPlayer.Clock.CurrentGlobalSpeed == 0.0)
            {
                var clockController = this.VideoPlayer.Clock.Controller;
                if (clockController != null)
                {
                    var currentTime = this.VideoPlayer.Clock.CurrentTime;
                    if (currentTime != null)
                    {
                        clockController.Seek(
                            (currentTime.Value - TimeSpan.FromMilliseconds(33.33)), TimeSeekOrigin.BeginTime);
                    }
                    clockController.Pause();
                }
                return;
            }

            var controller = this.VideoPlayer.Clock.Controller;
            if (controller != null && controller.SpeedRatio >= 0.11)
            {
                this.VideoPlayer.Clock.Controller.SpeedRatio = (this.VideoPlayer.Clock.Controller.SpeedRatio - 0.1);
            }
        }

        public void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            if (this.VideoPlayer.Clock.CurrentState != ClockState.Active)
            {
                return;
            }
            if (this.VideoPlayer.Clock.CurrentGlobalSpeed == 0.0)
            {
                var clockController = this.VideoPlayer.Clock.Controller;
                if (clockController != null)
                {
                    var currentTime = this.VideoPlayer.Clock.CurrentTime;
                    if (currentTime != null)
                    {
                        clockController.Seek(
                            (currentTime.Value + TimeSpan.FromMilliseconds(33.33)), TimeSeekOrigin.BeginTime);
                    }
                    clockController.Pause();
                }
                return;
            }

            var controller = this.VideoPlayer.Clock.Controller;
            if (controller != null && controller.SpeedRatio <= 8)
            {
                this.VideoPlayer.Clock.Controller.SpeedRatio = (this.VideoPlayer.Clock.Controller.SpeedRatio + 0.1);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.LoadVideo();
        }
	}
}