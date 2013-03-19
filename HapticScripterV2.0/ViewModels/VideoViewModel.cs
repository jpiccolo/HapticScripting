using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.ViewModels
{
    using System.ComponentModel;

    public class VideoViewModel : INotifyPropertyChanged
    {
        private double speedRatio;
        public double SpeedRatio
        {
            get { return this.speedRatio; }
            set { this.SetField(ref this.speedRatio, value, "SpeedRatio"); }
        }

        private TimeSpan duration;
        public TimeSpan Duration
        {
            get { return this.duration; }
            set { this.SetField(ref this.duration, value, "Duration"); }
        }
        
        private TimeSpan position;
        public TimeSpan Position
        {
            get { return this.position; }
            set { this.SetField(ref this.position, value, "Position"); }   
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
