﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.UI
{
    using System.Windows.Input;

    public static class KeyBindings
    {
        public static RoutedCommand VideoPlayCommand = new RoutedCommand();
        public static RoutedCommand VideoBackwardCommand = new RoutedCommand();
        public static RoutedCommand VideoForwardCommand = new RoutedCommand();
    }
}
