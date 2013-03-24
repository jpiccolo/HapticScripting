using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Media;

    using HapticScripterV2._0.UIElements;

    public class TimelineViewModel : INotifyPropertyChanged
    {
        public TimelineViewModel()
        {
            secondsList = new ObservableCollection<SecondsLine>();
            secondsList.Add(new SecondsLine("", 485));
            for (int i = 1; i < 10; i++)
            {
                TimeSpan t = new TimeSpan(0, 0, i);
                string s = t.ToString();

                secondsList.Add(new SecondsLine(s, 500));
            }
        }


        public ScrollViewer TimelineScroller;

        private ObservableCollection<SecondsLine> secondsList;
        public ObservableCollection<SecondsLine> SecondsList
        {
            get { return this.secondsList; }
            set { this.SetField(ref this.secondsList, value, "SecondsList"); }
        }

        public void ProcessTimelineRuler()
        {
            var sl = new ObservableCollection<SecondsLine>();

            sl.Add(new SecondsLine("", 485));

            for (int i = 1; i < AppViewModel.VideoViewModel.Duration.TotalSeconds; i++)
            {
                TimeSpan t = new TimeSpan(0, 0, i);
                string s = t.ToString();

                sl.Add(new SecondsLine(s, 500));
            }

            sl.Add(new SecondsLine("", (int)((AppViewModel.VideoViewModel.Duration.TotalMilliseconds) - (AppViewModel.VideoViewModel.Duration.TotalSeconds * 1000))));

            SecondsList = sl;
        }

        public enum ViewLevel
        {
            Level1 = 10,
            Level2 = 20,
            Level3 = 30,
            Level4 = 40,
            Level5 = 50
        }

        private double videoPositionInTimelineX;
        public double VideoPositionInTimelineX
        {
            get { return this.videoPositionInTimelineX; }
            set { this.SetField(ref this.videoPositionInTimelineX, value, "VideoPositionInTimelineX"); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class SecondsLine
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public int Left { get; set; }

        public SecondsLine(string label, int left)
        {
            this.Left = left;
            this.Label = label;
        }
    }
}
