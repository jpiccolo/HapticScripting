namespace HapticScripterV2._0.ViewModels
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel;

    using HapticScripterV2._0.Models;

    #endregion

    public class DataViewModel : INotifyPropertyChanged
    {
        #region Fields

        private BindingList<HapticEvent> bothAxisData;
        private BindingList<HapticEvent> bothPeriodicData;
        private BindingList<HapticEvent> bottomAxisData;
        private BindingList<HapticEvent> bottomPeriodicData;
        private BindingList<HapticEvent> heatAxisData;
        private BindingList<HapticEvent> lubeAxisData;
        private BindingList<HapticEvent> squeezeAxisData;
        private BindingList<HapticEvent> squeezePeriodicData;
        private BindingList<HapticEvent> stopAxisData;
        private BindingList<HapticEvent> topAxisData;
        private BindingList<HapticEvent> topPeriodicData;

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        public BindingList<HapticEvent> TopAxisData { get { return this.topAxisData; } set { this.SetField(ref this.topAxisData, value, "TopAxisData"); } }
        public BindingList<HapticEvent> BothAxisData { get { return this.bothAxisData; } set { this.SetField(ref this.bothAxisData, value, "BothAxisData"); } }
        public BindingList<HapticEvent> BottomAxisData { get { return this.bottomAxisData; } set { this.SetField(ref this.bottomAxisData, value, "BottomAxisData"); } }
        public BindingList<HapticEvent> SqueezeAxisData { get { return this.squeezeAxisData; } set { this.SetField(ref this.squeezeAxisData, value, "SqueezeAxisData"); } }

        public BindingList<HapticEvent> TopPeriodicData { get { return this.topPeriodicData; } set { this.SetField(ref this.topPeriodicData, value, "TopPeriodicData"); } }
        public BindingList<HapticEvent> BothPeriodicData { get { return this.bothPeriodicData; } set { this.SetField(ref this.bothPeriodicData, value, "BothPeriodicData"); } }
        public BindingList<HapticEvent> BottomPeriodicData { get { return this.bottomPeriodicData; } set { this.SetField(ref this.bottomPeriodicData, value, "BottomPeriodicData"); } }
        public BindingList<HapticEvent> SqueezePeriodicData { get { return this.squeezePeriodicData; } set { this.SetField(ref this.squeezePeriodicData, value, "SqueezePeriodicData"); } }

        public BindingList<HapticEvent> HeatAxisData { get { return this.heatAxisData; } set { this.SetField(ref this.heatAxisData, value, "HeatAxisData"); } }
        public BindingList<HapticEvent> LubeAxisData { get { return this.lubeAxisData; } set { this.SetField(ref this.lubeAxisData, value, "LubeAxisData"); } }
        public BindingList<HapticEvent> StopAxisData { get { return this.stopAxisData; } set { this.SetField(ref this.stopAxisData, value, "StopAxisData"); } }
        
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