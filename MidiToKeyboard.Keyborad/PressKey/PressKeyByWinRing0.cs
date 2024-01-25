using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MidiToKeyboard.Keyborad.DriverStageHelper;

namespace MidiToKeyboard.Keyborad.PressKey
{
    public class PressKeyByWinRing0 : IPressKey
    {
        public bool Initialize(EnumWindowsType winType)
        {
            return WinRing0.init();
        }

        public void KeyDown(char key)
        {
            WinRing0.KeyDown(key);//按下
        }

        public async Task KeyPress(char key, double milliseconds)
        {
            KeyDown(key);//按下
            await Task.Delay(TimeSpan.FromMilliseconds(milliseconds));
            KeyUp(key);//松开
        }

        public void KeyUp(char key)
        {
            WinRing0.KeyUp(key);//松开
        }
    }
}
