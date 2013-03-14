using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HapticScripter.UI
{
    public partial class MouseOperations
    {
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);
    } 
}
