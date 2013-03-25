namespace HapticScripterV2._0.Factories
{
    #region

    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;

    using HapticScripterV2._0.Models;
    using HapticScripterV2._0.ViewModels;

    #endregion

    public static class RealTouchFactory
    {
        #region Public Methods and Operators

        public static Task FixErrors()
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        foreach (HapticEvent item in AppViewModel.DataViewModel.TopAxisData)
                        {
                            item.FixEvent();
                        }

                        foreach (var item in AppViewModel.DataViewModel.BothAxisData)
                        {
                            item.FixEvent();
                        }

                        foreach (var item in AppViewModel.DataViewModel.BottomAxisData)
                        {
                            item.FixEvent();
                        }

                        foreach (var item in AppViewModel.DataViewModel.SqueezeAxisData)
                        {
                            item.FixEvent();
                        }

                        foreach (var item in AppViewModel.DataViewModel.TopPeriodicData)
                        {
                            item.FixEvent();
                        }
                                
                        foreach (var item in AppViewModel.DataViewModel.BothPeriodicData)
                        {
                            item.FixEvent();
                        }
                        AppViewModel.DataViewModel.BothPeriodicData.Invalidate();

                        foreach (var item in AppViewModel.DataViewModel.BottomPeriodicData)
                        {
                            item.FixEvent();
                        }

                        foreach (var item in AppViewModel.DataViewModel.SqueezePeriodicData)
                        {
                            item.FixEvent();
                        }
                                
                    });
        }

        public static Task ParseScript(string si)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        string[] lines = null;
                        try
                        {
                            lines = File.ReadAllLines(si);
                        }
                        catch (Exception ex)
                        {
                            //Logger.LogException(ex);
                        }

                        if (lines == null)
                        {
                            MessageBox.Show("Problem parsing script.txt!");
                        }

                        var topAxis = new HapticCollection();
                        var bothAxis = new HapticCollection();
                        var bottomAxis = new HapticCollection();
                        var squeezeAxis = new HapticCollection();
                        var topPeriodic = new HapticCollection();
                        var bothPeriodic = new HapticCollection();
                        var bottomPeriodic = new HapticCollection();
                        var squeezePeriodic = new HapticCollection();
                        var lube = new HapticCollection();
                        var heat = new HapticCollection();
                        var stop = new HapticCollection();

                        foreach (string s in lines)
                        {
                            string[] split = s.Split(' ');
                            HapticEvent rt = new HapticEvent();

                            switch (split[1])
                            {
                                case "V":
                                    {
                                        rt.Start = Convert.ToInt32(split[0]);
                                        rt.Magnitude = Convert.ToInt32(split[2]);

                                        rt.Direction = (String.CompareOrdinal("IN", split[4]) == 0)
                                                           ? HapticEvent.DirectionType.In
                                                           : HapticEvent.DirectionType.Out;
                                        rt.Duration = Convert.ToInt32(split[5]);
                                        rt.InMagnitude = Convert.ToInt32(split[6]);
                                        rt.InDuration = Convert.ToInt32(split[7]);
                                        rt.OutMagnitude = Convert.ToInt32(split[8]);
                                        rt.OutDuration = Convert.ToInt32(split[9]);

                                        switch (split[3])
                                        {
                                            case "U":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.AxisBoth;
                                                    bothAxis.Add(rt);
                                                    break;
                                                }
                                            case "T":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.AxisTop;
                                                    topAxis.Add(rt);
                                                    break;
                                                }
                                            case "B":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.AxisBottom;
                                                    bottomAxis.Add(rt);
                                                    break;
                                                }
                                            case "S":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.AxisSqueeze;
                                                    squeezeAxis.Add(rt);
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "P":
                                    {
                                        rt.Start = Convert.ToInt32(split[0]);
                                        rt.Period = Convert.ToInt32(split[2]);
                                        rt.Magnitude = Convert.ToInt32(split[3]);

                                        rt.Direction = (String.CompareOrdinal("IN", split[5]) == 0)
                                                           ? HapticEvent.DirectionType.In
                                                           : HapticEvent.DirectionType.Out;
                                        rt.Duration = Convert.ToInt32(split[6]);
                                        rt.InMagnitude = Convert.ToInt32(split[7]);
                                        rt.InDuration = Convert.ToInt32(split[8]);
                                        rt.OutMagnitude = Convert.ToInt32(split[9]);
                                        rt.OutDuration = Convert.ToInt32(split[10]);

                                        switch (split[4])
                                        {
                                            case "U":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.PeriodicBoth;
                                                    bothPeriodic.Add(rt);
                                                    break;
                                                }
                                            case "T":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.PeriodicTop;
                                                    topPeriodic.Add(rt);
                                                    break;
                                                }
                                            case "B":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.PeriodicBottom;
                                                    bottomPeriodic.Add(rt);
                                                    break;
                                                }
                                            case "S":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.PeriodicSqueeze;
                                                    squeezePeriodic.Add(rt);
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "H":
                                    {
                                        rt.Start = Convert.ToInt32(split[0]);
                                        rt.Magnitude = Convert.ToInt32(split[2]);
                                        rt.Duration = 100;

                                        heat.Add(rt);
                                        break;
                                    }
                                case "L":
                                    {
                                        rt.Start = Convert.ToInt32(split[0]);
                                        rt.Magnitude = Convert.ToInt32(split[2]);
                                        rt.Duration = Convert.ToInt32(split[3]);

                                        lube.Add(rt);
                                        break;
                                    }
                                case "S":
                                    {
                                        rt.Start = Convert.ToInt32(split[0]);
                                        rt.Duration = 100;
                                        switch (split[2])
                                        {
                                            case "A":
                                                {
                                                    rt.StopType = HapticEvent.TypeOfStop.All;
                                                    break;
                                                }
                                            case "H":
                                                {
                                                    rt.StopType = HapticEvent.TypeOfStop.Heater;
                                                    break;
                                                }
                                            case "T":
                                                {
                                                    rt.StopType = HapticEvent.TypeOfStop.TopBelt;
                                                    break;
                                                }
                                            case "B":
                                                {
                                                    rt.StopType = HapticEvent.TypeOfStop.BottomBelt;
                                                    break;
                                                }
                                            case "U":
                                                {
                                                    rt.StopType = HapticEvent.TypeOfStop.BothBelts;
                                                    break;
                                                }
                                            case "S":
                                                {
                                                    rt.StopType = HapticEvent.TypeOfStop.Squeeze;
                                                    break;
                                                }
                                        }
                                        stop.Add(rt);
                                        break;
                                    }
                            }
                        }

                        AppViewModel.DataViewModel.TopAxisData = topAxis;
                        AppViewModel.DataViewModel.BothAxisData = bothAxis;
                        AppViewModel.DataViewModel.BottomAxisData = bottomAxis;
                        AppViewModel.DataViewModel.SqueezeAxisData = squeezeAxis;
                        AppViewModel.DataViewModel.TopPeriodicData = topPeriodic;
                        AppViewModel.DataViewModel.BothPeriodicData = bothPeriodic;
                        AppViewModel.DataViewModel.BottomPeriodicData = bottomPeriodic;
                        AppViewModel.DataViewModel.SqueezePeriodicData = squeezePeriodic;
                        AppViewModel.DataViewModel.LubeAxisData = lube;
                        AppViewModel.DataViewModel.HeatAxisData = heat;
                        AppViewModel.DataViewModel.StopAxisData = stop;
                    });
        }

        #endregion
    }
}