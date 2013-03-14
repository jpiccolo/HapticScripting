using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.Data
{
    public class HapticEvent
    {
        public int Start { get; set; }
        public int Duration { get; set; }
        public int Magnitude { get; set; }

        public string Points { get { return "this is what?"; } }
    }
}
