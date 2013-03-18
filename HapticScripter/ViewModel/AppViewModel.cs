using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.ViewModel
{
    public class AppViewModel
    {
        private static TimelineControlViewModel timelineControlViewModel = new TimelineControlViewModel();
        private static DataViewModel dataViewModel = new DataViewModel();
        private static VideoPlayerControlViewModel videoPlayerControlViewModel = new VideoPlayerControlViewModel();


        public static DataViewModel DataViewModel
        {
            get { return dataViewModel; } 
            //set { AppViewModel.dataViewModel = value; }
        }
        public static TimelineControlViewModel TimelineControlViewModel
        {
            get { return timelineControlViewModel; } 
            //set { this.timelineControlViewModel = value; }
        }

        public static VideoPlayerControlViewModel VideoPlayerControlViewModel
        {
            get { return videoPlayerControlViewModel; } 
            //set { this.videoPlayerControlViewModel = value; }
        }
    }
}
