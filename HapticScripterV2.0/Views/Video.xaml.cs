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

    using HapticScripterV2._0.Factories;
    using HapticScripterV2._0.Media;
    using HapticScripterV2._0.UIElements;
    using HapticScripterV2._0.ViewModels;

    using WindowsMediaLib;

    /// <summary>
    /// Interaction logic for Video.xaml
    /// </summary>
    public partial class Video : UserControl
    {
        public Video() { InitializeComponent(); }

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
                controller.SpeedRatio = (controller.SpeedRatio - 0.1);
            }
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
                controller.SpeedRatio = (controller.SpeedRatio + 0.1);
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
                var d = (currentTime.Value.TotalMilliseconds / 2)
                        - (AppViewModel.TimelineViewModel.TimelineScroller.ViewportWidth / 2);

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

            KeyBindings.VideoBackwardCommand.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt));
            this.CommandBindings.Add(new CommandBinding(KeyBindings.VideoBackwardCommand, this.BackwardButton_Click));

            KeyBindings.VideoPlayCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
            this.CommandBindings.Add(new CommandBinding(KeyBindings.VideoPlayCommand, this.PlayButton_Click));

            KeyBindings.VideoForwardCommand.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Alt));
            this.CommandBindings.Add(new CommandBinding(KeyBindings.VideoForwardCommand, this.ForwardButton_Click));
        }

        private void VideoSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            var clock = this.VideoPlayer.Clock;
            if (clock == null)
            {
                return;
            }
            //Is Active
            switch (this.VideoPlayer.Clock.CurrentState)
            {
                case ClockState.Active:

                    if (this.VideoPlayer.Clock.CurrentGlobalSpeed != 0.0)
                    {
                        //Is Playing
                        var clockController = this.VideoPlayer.Clock.Controller;
                        if (clockController != null)
                        {
                            clockController.Pause();
                        }
                    }

                    return;
            }
        }

        private void VideoSlider_DragCompleted(
            object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (AppViewModel.VideoViewModel.Position.TotalSeconds > 0)
            {
                var clockController = this.VideoPlayer.Clock.Controller;
                if (clockController != null)
                {
                    var currentTime = this.VideoPlayer.Clock.CurrentTime;
                    if (currentTime != null)
                    {
                        clockController.Seek(
                            TimeSpan.FromSeconds(VideoSlider.Value * AppViewModel.VideoViewModel.Duration.TotalSeconds),
                            TimeSeekOrigin.BeginTime);
                    }
                    clockController.Pause();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //WMReaderCallback objMetaData = new WMReaderCallback();

            //objMetaData.Report(@"C:\236179-wmv.wmv");

            RealTouchFactory.ParseScript(@"C:\script.txt");
            RealTouchFactory.FixErrors();
        }
    }
}

