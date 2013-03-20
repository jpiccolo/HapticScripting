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

namespace HapticScripterV2._0.Views
{
    using System.Windows.Media.Animation;

    using HapticScripterV2._0.ViewModels;

    /// <summary>
    /// Interaction logic for Video.xaml
    /// </summary>
    public partial class Video : UserControl
    {
        public Video() { InitializeComponent(); }

        private void BackwardButton_Click(object sender, RoutedEventArgs e) { }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
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

        private void ForwardButton_Click(object sender, RoutedEventArgs e) { }

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
                                                    AppViewModel.VideoViewModel.Duration =
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
                AppViewModel.VideoViewModel.SpeedRatio = clockController.SpeedRatio;
            }
        }

        private void SpeedRatioChanged(object sender, EventArgs e)
        {
            var clockController = this.VideoPlayer.Clock.Controller;
            if (clockController != null)
            {
                AppViewModel.VideoViewModel.SpeedRatio = clockController.SpeedRatio;
            }
        }


        private void PositionChanged(object sender, EventArgs e)
        {
            if (this.VideoPlayer.Clock.CurrentState != ClockState.Active)
            {
                return;
            }

            var currentTime = this.VideoPlayer.Clock.CurrentTime;
            if (currentTime != null)
            {
            //    //if (this.VideoPlayer.Clock.CurrentGlobalSpeed == 0.0)
            //    //{
            //    updateCount++;
            //    if (updateCount > 10)
            //    {
            //        //Console.WriteLine(DateTime.Now.TimeOfDay);
                    AppViewModel.VideoViewModel.Position = currentTime.Value;
                AppViewModel.TimelineViewModel.VideoPositionInTimelineX = currentTime.Value.TotalMilliseconds / 2;
                var d = (currentTime.Value.TotalMilliseconds / 2) - (AppViewModel.TimelineViewModel.TimelineScroller.ViewportWidth / 2);

                       AppViewModel.TimelineViewModel.TimelineScroller.ScrollToHorizontalOffset(d);
                //        updateCount = 0;
                //    }

            }
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

        private void VideoUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadVideo();
        }
    }
}

