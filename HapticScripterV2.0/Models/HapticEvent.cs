namespace HapticScripterV2._0.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Threading;

    #endregion

    public class HapticEvent : INotifyPropertyChanged
    {
        #region Fields

        private DirectionType direction;
        private int duration;
        private int inDuration;
        private int inMagnitude;
        private int magnitude;
        private int outDuration;
        private int outMagnitude;
        private int period;
        private int start;
        private TypeOfStop stopType;
        private HapticEventType type;

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Enums

        public enum DirectionType
        {
            In,
            Out
        }

        public enum HapticEventType
        {
            AxisTop,
            AxisBoth,
            AxisBottom,
            AxisSqueeze,
            PeriodicTop,
            PeriodicBoth,
            PeriodicBottom,
            PeriodicSqueeze,
            Lube,
            Heat,
            Stop
        }

        public enum TypeOfStop
        {
            All,
            Heater,
            TopBelt,
            BottomBelt,
            BothBelts,
            Squeeze
        }

        #endregion

        #region Public Properties

        public DirectionType Direction
        {
            get { return this.direction; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.direction, value, "Direction")), DispatcherPriority.Render);
            }
        }
        public int Duration
        {
            get { return this.duration; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.duration, value, "Duration")), DispatcherPriority.Render);
            }
        }
        public int InDuration
        {
            get { return this.inDuration; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.inDuration, value, "InDuration")), DispatcherPriority.Render);
            }
        }
        public int InMagnitude
        {
            get { return this.inMagnitude; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.inMagnitude, value, "InMagnitude")), DispatcherPriority.Render);
            }
        }
        public int Magnitude
        {
            get { return this.magnitude; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.magnitude, value, "Magnitude")), DispatcherPriority.Render);
            }
        }
        public int OutDuration
        {
            get { return this.outDuration; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.outDuration, value, "OutDuration")), DispatcherPriority.Render);
            }
        }
        public int OutMagnitude
        {
            get { return this.outMagnitude; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.outMagnitude, value, "OutMagnitude")),
                    DispatcherPriority.Render);
            }
        }
        public int Period
        {
            get { return this.period; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.period, value, "Period")), DispatcherPriority.Render);
            }
        }
        public int Start
        {
            get { return this.start; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.start, value, "Start")), DispatcherPriority.Render);
            }
        }
        public TypeOfStop StopType
        {
            get { return this.stopType; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.stopType, value, "StopType")), DispatcherPriority.Render);
            }
        }
        public HapticEventType Type
        {
            get { return this.type; }
            set
            {
                Application.Current.Dispatcher.Invoke(
                    (Action)(() => this.SetField(ref this.type, value, "Type")), DispatcherPriority.Render);
            }
        }

        #endregion

        #region Public Methods and Operators

        public void FixEvent()
        {
            if (((OutDuration > Duration) ||
                 (InDuration > Duration)) ||
                (InDuration + OutDuration) > Duration)
            {
                if (OutDuration == 0)
                {
                    InDuration = Duration;
                }
                else if (InDuration == 0)
                {
                    OutDuration = Duration;
                }
                else
                {
                    InDuration = Duration / 2;
                    OutDuration = Duration / 2;
                }
            }
        }

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