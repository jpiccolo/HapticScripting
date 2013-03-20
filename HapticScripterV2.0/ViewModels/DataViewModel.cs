namespace HapticScripterV2._0.ViewModels
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Threading.Tasks;

    using HapticScripterV2._0.Factories;
    using HapticScripterV2._0.Models;

    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;

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
}