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


        public int HeaderWidth
        {
            set
            {
                HeaderVisualHost = new HeaderVisualHost(value, ViewLevel.Level1);
            }
        }

        private HeaderVisualHost headerVisualHost;
        public HeaderVisualHost HeaderVisualHost
        {
            get { return this.headerVisualHost; }
            set { this.SetField(ref this.headerVisualHost, value, "HeaderVisualHost"); }
        }



    }
}
