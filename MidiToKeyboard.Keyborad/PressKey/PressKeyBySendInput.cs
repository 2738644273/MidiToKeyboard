using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;

using MidiToKeyboard.Keyborad.DriverStageHelper;
using MidiToKeyboard.Keyborad.PressKey;
using MidiToKeyBoard.Core.Constant;
using WindowsInput;

namespace TestKeyboard.PressKey
{
    public class PressKeyBySendInput : IPressKey
    {
        public bool Initialize(EnumWindowsType winType)
        {
            return true;
        }
        InputSimulator iputSimulator = new InputSimulator();
        public void KeyDown(EnumKey key)
        {
            iputSimulator.Keyboard.KeyDown((VirtualKeyCode)key);
        }

        public async Task KeyPress(EnumKey key, double milliseconds)
        {
            iputSimulator.Keyboard.KeyDown((VirtualKeyCode)key);
            await Task.Delay((int)milliseconds);
            iputSimulator.Keyboard.KeyUp((VirtualKeyCode)key);
        }

        public void KeyUp(EnumKey key)
        {
            iputSimulator.Keyboard.KeyUp((VirtualKeyCode)key);
        }
    }
}