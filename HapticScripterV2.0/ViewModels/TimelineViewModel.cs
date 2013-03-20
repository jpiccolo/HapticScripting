using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class TimelineViewModel : INotifyPropertyChanged
    {
        public ScrollViewer TimelineScroller;

        private int headerWidth;
        public int HeaderWidth
        {
            get { return this.headerWidth; }
            set { this.SetField(ref this.headerWidth, value, "HeaderWidth"); }
        }

        private ImageSource headerImageSource;
        public ImageSource HeaderImageSource
        {
            get { return this.headerImageSource; }
            set { this.SetField(ref this.headerImageSource, value, "HeaderImageSource"); }
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
}
