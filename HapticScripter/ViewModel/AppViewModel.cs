using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.ViewModel
{
    public class AppViewModel
    {
        private TimelineControlViewModel timelineControlViewModel = new TimelineControlViewModel();
        private DataViewModel dataViewModel = new DataViewModel();
        public DataViewModel DataViewModel { get { return this.dataViewModel; } set { this.dataViewModel = value; } }
        public TimelineControlViewModel TimelineControlViewModel { get { return this.timelineControlViewModel; } set { this.timelineControlViewModel = value; } }
    }
}
