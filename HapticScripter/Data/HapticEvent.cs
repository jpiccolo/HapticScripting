using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Data
{
    using System.ComponentModel;

    public class HapticEvent : INotifyPropertyChanged
    {
        private int start;
        private int duration;
        private int magnitude;
        private DirectionType direction;
        private int inDuration;
        private HapticEventType type;
        private int outMagnitude;
        private int outDuration;
        private int inMagnitude;
        public int Start { get { return this.start; } set { this.SetField(ref this.start, value, "Start"); } }
        public int Duration { get { return this.duration; } set { this.SetField(ref this.start, value, "Duration"); } }
        public int Magnitude { get { return this.magnitude; } set { this.SetField(ref this.start, value, "Magnitude"); } }


        public DirectionType Direction { get { return this.direction; } set { this.SetField(ref this.direction, value, "Direction"); } }


        public int InDuration { get { return this.inDuration; } set { this.SetField(ref this.inDuration, value, "InDuration"); } }
        public int InMagnitude { get { return this.inMagnitude; } set { this.SetField(ref this.inMagnitude, value, "InMagnitude"); } }

        public int OutDuration { get { return this.outDuration; } set { this.SetField(ref this.outDuration, value, "OutDuration"); } }
        public int OutMagnitude { get { return this.outMagnitude; } set { this.SetField(ref this.outMagnitude, value, "OutMagnitude"); } }

        public HapticEventType Type { get { return this.type; } set { this.SetField(ref this.type, value, "Type"); } }

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




        void blah()
        {
            using (var context = new RealTouchDatabaseEntities())
            {
                //var stdQuery = (from d in context.Classes
                //                select new { Class = d.ClassName, Teacher = d.ClassTeacher });

                //foreach (var q in stdQuery)
                //{
                //    Console.WriteLine("Class Name : " + q.Class + ", Class Teacher Name : " + q.Teacher);
                //}

                Console.ReadKey();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
