using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;

using MidiToKeyboard.Keyborad.DriverStageHelper;
using MidiToKeyboard.Keyborad.PressKey;
using MidiToKeyBoard.Core.Constant;

namespace TestKeyboard.PressKey
{
    public class PressKeyBySendInput : IPressKey
    {
        public bool Initialize(EnumWindowsType winType)
        {
            return true;
        }

        public void KeyDown(EnumKey key)
        {
            SendInputHelper.INPUT[] input = new SendInputHelper.INPUT[1];
            input[0].type = 1;
            short num = (short)key;
            input[0].ki.wVk = num;
            input[0].ki.dwFlags = 0;

            SendInputHelper.SendInput(1, input, Marshal.SizeOf(default(SendInputHelper.INPUT)));
        }

        public void KeyPress(EnumKey key, double milliseconds)
        {
            KeyDown(key);
            Thread.Sleep((int)milliseconds);
            KeyUp(key);
        }

        public void KeyUp(EnumKey key)
        {
            SendInputHelper.INPUT[] input = new SendInputHelper.INPUT[1];
            input[0].type = 1;
            short num = (short)key;
            input[0].ki.wVk = num;
            input[0].ki.dwFlags = 2;

            SendInputHelper.SendInput(1, input, Marshal.SizeOf(default(SendInputHelper.INPUT)));
        }
    }
}