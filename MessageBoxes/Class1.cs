using System;
using System.Runtime.InteropServices;

namespace MessageBoxes
{
    public class Alerts
    {
        [DllImport("user32.dll")]
        private static extern uint MessageBoxA(IntPtr hWnd, String caption, String message, uint type);

        public static void Alert(String caption, String message)
        {
            MessageBoxA((IntPtr)0, message, caption, 0x40);
        }
        public static void Error(String caption, String message)
        {
            MessageBoxA((IntPtr)0, "Message", "Error", 0x10);
        }

        public static bool Warning(String caption, String message)
        {
            //IDOK == 1
            return 1 == MessageBoxA((IntPtr)0, "Message", "Warning", 0x31);
        }

        public static bool Question(String caption, String message)
        {
            //IDYES == 6
            return 6 == MessageBoxA((IntPtr)0, "Message", "Warning", 0x24);
        }
    }
}
