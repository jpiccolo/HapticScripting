namespace HapticScripterV2._0.ViewModels
{
    public class AppViewModel
    {
        #region Static Fields

        private static readonly TimelineViewModel timelineViewModel = new TimelineViewModel();
        //private static DataViewModel dataViewModel = new DataViewModel();
        private static readonly VideoViewModel videoViewModel = new VideoViewModel();

        #endregion

        //public static DataViewModel DataViewModel
        //{
        //    get { return dataViewModel; }
        //    //set { AppViewModel.dataViewModel = value; }
        //}

        #region Public Properties

        public static TimelineViewModel TimelineViewModel
        {
            get { return timelineViewModel; }
            //set { this.timelineControlViewModel = value; }
        }

        public static VideoViewModel VideoViewModel
        {
            get { return videoViewModel; }
            //set { this.videoPlayerControlViewModel = value; }
        }

        #endregion
    }
}