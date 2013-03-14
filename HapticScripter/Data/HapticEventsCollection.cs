using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Data
{
    public class HapticEventsCollection
    {
        public List<HapticEvent> HapticEvents { get; private set; }

        public HapticEventsCollection()
        {
            HapticEvents = new List<HapticEvent>();
        }

        public void AddEvent(HapticEvent evt)
        {
            HapticEvents.Add(evt);
        }
    }
}
