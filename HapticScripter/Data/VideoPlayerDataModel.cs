using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Data
{
    using System.ComponentModel;

    public class VideoPlayerDataModel : INotifyPropertyChanged
    {
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        private int speedRatio;
        public int SpeedRatio
        {
            get { return speedRatio; }
            set { this.SetField(ref speedRatio, value, "SpeedRatio"); }
        }

        private string duration;
        public string Duration
        {
            get { return duration; }
            set { this.SetField(ref duration, value, "Duration"); }
        }
    }
}
