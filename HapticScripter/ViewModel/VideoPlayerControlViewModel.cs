namespace HapticScripter.ViewModel
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    #endregion

    public class VideoPlayerControlViewModel : INotifyPropertyChanged
    {
        // boiler-plate

        #region Fields

        private TimeSpan duration;
        private TimeSpan position;
        private double speedRatio;

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private double videoPositionMilliSeconds;
        public double VideoPositionMilliSeconds
        {
            get { return videoPositionMilliSeconds; }
            set
            {
                this.SetField(ref this.videoPositionMilliSeconds, value, "VideoPositionMilliSeconds");
            }
        }


        #region Public Properties

        public TimeSpan Duration
        {
            get { return this.duration; } 
            set
            {
                this.SetField(ref this.duration, value, "Duration");
                AppViewModel.TimelineControlViewModel.HeaderWidth = (int)(this.duration.TotalMilliseconds / 2);
            }
        }

        private int updateLineCount;
        public TimeSpan Position
        {
            get { return this.position; } 
            set
            {
                this.SetField(ref this.position, value, "Position");
                var milliSec = position.TotalMilliseconds;
                VideoPositionMilliSeconds = milliSec;
                //updateLineCount++;
                //if (updateLineCount > 10)
                //{
                //    var milliSec = position.TotalMilliseconds;
                //    VideoPositionMilliSeconds = milliSec;
                //    updateLineCount = 0;
                //}
            }
        }
        public double SpeedRatio { get { return this.speedRatio; } set { this.SetField(ref this.speedRatio, value, "SpeedRatio"); } }

        #endregion

        #region Methods

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

        #endregion
    }
}