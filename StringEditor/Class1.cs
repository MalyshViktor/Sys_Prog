using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace StringEditor
{
    public class Strings
    {
        [DllImport("user32.dll")]
        private static extern uint MessageBoxA(IntPtr hWnd, String caption, String message, uint type);

        public static void Reverse(String caption, String message)
        {
            char[] charArray = message.ToCharArray();
            Array.Reverse(charArray);
            string output = new string(charArray);
            MessageBoxA((IntPtr)0, output, caption, 0x40);
        }

        public static void SingleSpace(String caption, String message)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ] {2,}", options);
            message = regex.Replace(message, " ");
            MessageBoxA((IntPtr)0, message, caption, 0x40);
        }
    }
}
