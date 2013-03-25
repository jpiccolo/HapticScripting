namespace HapticScripterV2._0.ViewModels
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    using HapticScripterV2._0.Factories;
    using HapticScripterV2._0.Models;

    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;

    #endregion

    public class DataViewModel : INotifyPropertyChanged
    {
        #region Fields

        private HapticCollection bothAxisData;
        private HapticCollection bothPeriodicData;
        private HapticCollection bottomAxisData;
        private HapticCollection bottomPeriodicData;
        private HapticCollection heatAxisData;
        private HapticCollection lubeAxisData;
        private HapticCollection squeezeAxisData;
        private HapticCollection squeezePeriodicData;
        private HapticCollection stopAxisData;
        private HapticCollection topAxisData;
        private HapticCollection  topPeriodicData;

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        public HapticCollection TopAxisData { 
            get
            {
                return this.topAxisData;
            } 
            set
            {
                this.SetField(ref this.topAxisData, value, "TopAxisData");
                this.topAxisData.Invalidate();
            } }

        public HapticCollection BothAxisData { 
            get { return this.bothAxisData; } 
            set
            {
                this.SetField(ref this.bothAxisData, value, "BothAxisData");
                this.bothAxisData.Invalidate();
            } }

        public HapticCollection BottomAxisData { get { return this.bottomAxisData; } set { this.SetField(ref this.bottomAxisData, value, "BottomAxisData"); } }
        public HapticCollection SqueezeAxisData { get { return this.squeezeAxisData; } set { this.SetField(ref this.squeezeAxisData, value, "SqueezeAxisData"); } }

        public HapticCollection TopPeriodicData { get { return this.topPeriodicData; } set { this.SetField(ref this.topPeriodicData, value, "TopPeriodicData"); } }
        public HapticCollection BothPeriodicData { get { return this.bothPeriodicData; } set { this.SetField(ref this.bothPeriodicData, value, "BothPeriodicData"); } }
        public HapticCollection BottomPeriodicData { get { return this.bottomPeriodicData; } set { this.SetField(ref this.bottomPeriodicData, value, "BottomPeriodicData"); } }
        public HapticCollection SqueezePeriodicData { get { return this.squeezePeriodicData; } set { this.SetField(ref this.squeezePeriodicData, value, "SqueezePeriodicData"); } }

        public HapticCollection HeatAxisData { get { return this.heatAxisData; } set { this.SetField(ref this.heatAxisData, value, "HeatAxisData"); } }
        public HapticCollection LubeAxisData { get { return this.lubeAxisData; } set { this.SetField(ref this.lubeAxisData, value, "LubeAxisData"); } }
        public HapticCollection StopAxisData { get { return this.stopAxisData; } set { this.SetField(ref this.stopAxisData, value, "StopAxisData"); } }

        private string projectFilePath;
        private string scriptFilePath;
        private string videoFilePath;
        private string infoFilePath;
        private string projectName;
        private double videoDuration;
        private bool isDirty;

        public string ProjectFilePath { get { return this.projectFilePath; } set { this.SetField(ref this.projectFilePath, value, "ProjectFilePath"); } }
        public string ScriptFilePath { get { return this.scriptFilePath; } set { this.SetField(ref this.scriptFilePath, value, "ScriptFilePath"); } }
        public string VideoFilePath { get { return this.videoFilePath; } set { this.SetField(ref this.videoFilePath, value, "VideoFilePath"); } }
        public string InfoFilePath { get { return this.infoFilePath; } set { this.SetField(ref this.infoFilePath, value, "InfoFilePath"); } }
        public string ProjectName { get { return this.projectName; } set { this.SetField(ref this.projectName, value, "ProjectName"); } }
        public double VideoDuration { get { return this.videoDuration; } set { this.SetField(ref this.videoDuration, value, "VideoDuration"); } }
        public bool IsDirty { get { return this.isDirty; } set { this.SetField(ref this.isDirty, value, "IsDirty"); } }

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

        private Action<Task> projectCallback;
        public void LoadProject(Action<Task> callback)
        {
            projectCallback = callback;

            ProjectFactory.OpenProject(projectFilePath).ContinueWith(OnProjectLoaded);
        }

        private void OnProjectLoaded(Task obj)
        {
            
            RealTouchFactory.ParseScript(AppViewModel.DataViewModel.ScriptFilePath).ContinueWith(OnScriptParsed);
        }

        private void OnScriptParsed(Task obj)
        {
            throw new NotImplementedException();
        }
    }

    public class HapticCollection : BindingList<HapticEvent>, ZoomableCanvas.ISpatialItemsSource
    {
        #region Implementation of ISpatialItemsSource

        public IEnumerable<int> Query(Rect rectangle)
        {
            rectangle.Intersect(Extent);

            for (int i = 0; i < this.Items.Count; i++)
            {
                double start = (this.Items[i].Start / 2.0);

                if (start >= Math.Max(0, (rectangle.X-2000)) && start <= (rectangle.X + rectangle.Width))
                {
                    yield return (i);
                }
            }
        }

        public Rect Extent
        {
            get
            {
                return new Rect(
                    AppViewModel.TimelineViewModel.TimelineScroller.HorizontalOffset, 
                    0, 
                    AppViewModel.TimelineViewModel.TimelineScroller.ViewportWidth, 
                    AppViewModel.TimelineViewModel.TimelineScroller.ViewportHeight);
            }
        }

        public event EventHandler ExtentChanged;
        public event EventHandler QueryInvalidated;

        public void AddNewEvent(HapticEvent evt)
        {
            Application.Current.Dispatcher.Invoke(
                (Action)(() => this.Add(evt)),
                DispatcherPriority.Render);
        }
        #endregion

        internal void Invalidate()
        {
            if (ExtentChanged != null)
            {
                ExtentChanged(this, EventArgs.Empty);
            }
            if (QueryInvalidated != null)
            {
                QueryInvalidated(this, EventArgs.Empty);
            }
    }

        public void InvalidateExtent() { ExtentChanged(this, EventArgs.Empty); }
    }
}