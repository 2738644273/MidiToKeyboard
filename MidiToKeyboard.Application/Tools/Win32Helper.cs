﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MidiToKeyboard.App.Tools
{
    
        public class Win32Helper
        {
            [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
            public static extern int MciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
            [DllImport("user32.dll")]
             public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }

}
