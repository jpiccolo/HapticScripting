using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripterV2._0.UIElements
{
    using System.Windows.Input;

    public class KeyBindings
    {
        public static RoutedCommand VideoPlayCommand = new RoutedCommand();
        public static RoutedCommand VideoBackwardCommand = new RoutedCommand();
        public static RoutedCommand VideoForwardCommand = new RoutedCommand();
    }
}
