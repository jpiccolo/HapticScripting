using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.Factories
{
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;

    using HapticScripterV2._0.Models;
    using HapticScripterV2._0.ViewModels;

    public static class RealTouchFactory
    {
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
                        //Logger.Log("*************Script File*************");
                        //foreach (var line in lines)
                        //{
                        //    Logger.Log(line);
                        //}
                        //Logger.Log("*************End Script File*************");

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
                                                    AppViewModel.DataViewModel.BothAxisData.Add(rt);
                                                    break;
                                                }
                                            case "T":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.AxisTop;
                                                    AppViewModel.DataViewModel.TopAxisData.Add(rt);
                                                    break;
                                                }
                                            case "B":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.AxisBottom;
                                                    AppViewModel.DataViewModel.BottomAxisData.Add(rt);
                                                    break;
                                                }
                                            case "S":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.AxisSqueeze;
                                                    AppViewModel.DataViewModel.SqueezeAxisData.Add(rt);
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
                                                    AppViewModel.DataViewModel.BothPeriodicData.Add(rt);
                                                    break;
                                                }
                                            case "T":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.PeriodicTop;
                                                    AppViewModel.DataViewModel.TopPeriodicData.Add(rt);
                                                    break;
                                                }
                                            case "B":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.PeriodicBottom;
                                                    AppViewModel.DataViewModel.BottomPeriodicData.Add(rt);
                                                    break;
                                                }
                                            case "S":
                                                {
                                                    rt.Type = HapticEvent.HapticEventType.PeriodicSqueeze;
                                                    AppViewModel.DataViewModel.SqueezePeriodicData.Add(rt);
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

                                        AppViewModel.DataViewModel.HeatAxisData.Add(rt);
                                        break;
                                    }
                                case "L":
                                    {
                                        rt.Start = Convert.ToInt32(split[0]);
                                        rt.Magnitude = Convert.ToInt32(split[2]);
                                        rt.Duration = Convert.ToInt32(split[3]);

                                        AppViewModel.DataViewModel.LubeAxisData.Add(rt);
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
                                        AppViewModel.DataViewModel.StopAxisData.Add(rt);
                                        break;
                                    }
                            }
                        }
                    });

            AppViewModel.DataViewModel.TopAxisData.RaiseListChangedEvents = true;
        }
    }
}
