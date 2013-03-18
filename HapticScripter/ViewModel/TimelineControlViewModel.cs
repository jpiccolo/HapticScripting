using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.ViewModel
{
    using System.ComponentModel;

    using HapticScripter.UI;

    public class TimelineControlViewModel : INotifyPropertyChanged
    {
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

        public enum ViewLevel
        {
            Level1 = 10,
            Level2 = 20,
            Level3 = 30,
            Level4 = 40,
            Level5 = 50
        }

        private int headerWidth;
        public int HeaderWidth
        {
            get { return this.headerWidth; }
            set
            {
                this.SetField(ref this.headerWidth, value, "HeaderWidth");
                HeaderVisualHost = new HeaderVisualHost(value, ViewLevel.Level1);
                LineVisualHost = new LineVisualHost(500);
            }
        }

        private HeaderVisualHost headerVisualHost = new HeaderVisualHost(1000, ViewLevel.Level1);
        private double timelineScrollViewerViewportWidth;
        private LineVisualHost lineVisualHost = new LineVisualHost(100);
        public HeaderVisualHost HeaderVisualHost
        {
            get { return this.headerVisualHost; }
            set
            {
                this.SetField(ref this.headerVisualHost, value, "HeaderVisualHost");
            }
        }

        public double TimelineScrollViewerViewportWidth
        {
            get { return this.timelineScrollViewerViewportWidth; }
            set { this.SetField(ref this.timelineScrollViewerViewportWidth, value, "TimelineScrollViewerViewportWidth"); }
        }

        public LineVisualHost LineVisualHost
        {
            get { return this.lineVisualHost; }
            set { this.SetField(ref this.lineVisualHost, value, "LineVisualHost"); }
        }
    }
}
