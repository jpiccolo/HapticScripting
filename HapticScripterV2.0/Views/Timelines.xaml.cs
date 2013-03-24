namespace HapticScripterV2._0.Views
{
    #region

    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    using HapticScripterV2._0.Models;
    using HapticScripterV2._0.ViewModels;

    #endregion

    /// <summary>
    ///   Interaction logic for Timelines.xaml
    /// </summary>
    public partial class Timelines : UserControl
    {
        #region Constructors and Destructors

        public Timelines() { InitializeComponent(); }

        #endregion

        #region Methods

        private void TimelineScroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (AppViewModel.DataViewModel.TopAxisData != null)
            {
                AppViewModel.DataViewModel.TopAxisData.Invalidate();
            }

            if (AppViewModel.DataViewModel.BothAxisData != null)
            {
                AppViewModel.DataViewModel.BothAxisData.Invalidate();
            }

            if (AppViewModel.DataViewModel.BottomAxisData != null)
            {
                AppViewModel.DataViewModel.BottomAxisData.Invalidate();
            }

            if (AppViewModel.DataViewModel.SqueezeAxisData != null)
            {
                AppViewModel.DataViewModel.SqueezeAxisData.Invalidate();
            }

            if (AppViewModel.DataViewModel.TopPeriodicData != null)
            {
                AppViewModel.DataViewModel.TopPeriodicData.Invalidate();
            }

            if (AppViewModel.DataViewModel.BothPeriodicData != null)
            {
                AppViewModel.DataViewModel.BothPeriodicData.Invalidate();
            }

            if (AppViewModel.DataViewModel.BottomPeriodicData != null)
            {
                AppViewModel.DataViewModel.BottomPeriodicData.Invalidate();
            }

            if (AppViewModel.DataViewModel.SqueezePeriodicData != null)
            {
                AppViewModel.DataViewModel.SqueezePeriodicData.Invalidate();
            }

            if (AppViewModel.DataViewModel.LubeAxisData != null)
            {
                AppViewModel.DataViewModel.LubeAxisData.Invalidate();
            }

            if (AppViewModel.DataViewModel.HeatAxisData != null)
            {
                AppViewModel.DataViewModel.HeatAxisData.Invalidate();
            }

            if (AppViewModel.DataViewModel.StopAxisData != null)
            {
                AppViewModel.DataViewModel.StopAxisData.Invalidate();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AppViewModel.TimelineViewModel.TimelineScroller = TimelineScroller;

            int count = 5000;
            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.TopAxisData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.BothAxisData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.BottomAxisData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.SqueezeAxisData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.TopPeriodicData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.BothPeriodicData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.BottomPeriodicData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.SqueezePeriodicData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.LubeAxisData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.HeatAxisData = temp;
                    });

            Task.Factory.StartNew(
                () =>
                    {
                        var temp = new HapticCollection();
                        for (int i = 0; i < count; i++)
                        {
                            var evt = new HapticEvent
                                          {
                                              Direction = HapticEvent.DirectionType.In,
                                              Duration = 100,
                                              InDuration = 25,
                                              InMagnitude = 100,
                                              Magnitude = 200,
                                              OutDuration = 25,
                                              OutMagnitude = 100,
                                              Period = 5,
                                              Start = 100 + (100 * i),
                                              StopType = HapticEvent.TypeOfStop.All
                                          };

                            temp.Add(evt);
                        }
                        AppViewModel.DataViewModel.StopAxisData = temp;
                    });
        }

        #endregion
    }
}