namespace HapticScripter.UserControls
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls;

    public partial class VideoPlayerControlModel : UserControl
    {
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }


        private int speedRatio;
        public int SpeedRatio
        {
            get { return this.speedRatio; }
            set { this.SetField(ref this.speedRatio, value, "SpeedRatio"); }
        }

        private string duration = "21";
        public string Duration
        {
            get { return this.duration; }
            set { this.SetField(ref this.duration, value, "Duration"); }
        }
    }
}
