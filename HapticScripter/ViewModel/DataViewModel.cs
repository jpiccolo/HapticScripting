using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.ViewModel
{
    using System.ComponentModel;

    using HapticScripter.Data;

    public class DataViewModel : INotifyPropertyChanged
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

        private BindingList<HapticEvent> topAxisData;
        public BindingList<HapticEvent> TopAxisData
        {
            get { return this.topAxisData; }
            set { this.SetField(ref this.topAxisData, value, "TopAxisData"); }
        }

        private BindingList<HapticEvent> bothAxisData;
        public BindingList<HapticEvent> BothAxisData
        {
            get { return this.bothAxisData; }
            set { this.SetField(ref this.bothAxisData, value, "BothAxisData"); }
        }

        private BindingList<HapticEvent> bottomAxisData;
        public BindingList<HapticEvent> BottomAxisData
        {
            get { return this.bottomAxisData; }
            set { this.SetField(ref this.bottomAxisData, value, "BottomAxisData"); }
        }

        private BindingList<HapticEvent> squeezeAxisData;
        public BindingList<HapticEvent> SqueezeAxisData
        {
            get { return this.squeezeAxisData; }
            set { this.SetField(ref this.squeezeAxisData, value, "SqueezeAxisData"); }
        }

        private BindingList<HapticEvent> topPeriodicData;
        public BindingList<HapticEvent> TopPeriodicData
        {
            get { return this.topPeriodicData; }
            set { this.SetField(ref this.topPeriodicData, value, "TopPeriodicData"); }
        }

        private BindingList<HapticEvent> bothPeriodicData;
        public BindingList<HapticEvent> BothPeriodicData
        {
            get { return this.bothPeriodicData; }
            set { this.SetField(ref this.bothPeriodicData, value, "BothPeriodicData"); }
        }

        private BindingList<HapticEvent> bottomPeriodicData;
        public BindingList<HapticEvent> BottomPeriodicData
        {
            get { return this.bottomPeriodicData; }
            set { this.SetField(ref this.bottomPeriodicData, value, "BottomPeriodicData"); }
        }

        private BindingList<HapticEvent> squeezePeriodicData;
        public BindingList<HapticEvent> SqueezePeriodicData
        {
            get { return this.squeezePeriodicData; }
            set { this.SetField(ref this.squeezePeriodicData, value, "SqueezePeriodicData"); }
        }

        private BindingList<HapticEvent> lubeAxisData;
        public BindingList<HapticEvent> LubeAxisData
        {
            get { return this.lubeAxisData; }
            set { this.SetField(ref this.lubeAxisData, value, "LubeAxisData"); }
        }

        private BindingList<HapticEvent> heatAxisData;
        public BindingList<HapticEvent> HeatAxisData
        {
            get { return this.heatAxisData; }
            set { this.SetField(ref this.heatAxisData, value, "HeatAxisData"); }
        }

        private BindingList<HapticEvent> stopAxisData;
        public BindingList<HapticEvent> StopAxisData
        {
            get { return this.stopAxisData; }
            set { this.SetField(ref this.stopAxisData, value, "StopAxisData"); }
        }
    }
}
