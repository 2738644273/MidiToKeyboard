using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MidiToKeyboard.Keyborad.DriverStageHelper;
using MidiToKeyBoard.Core.Constant;

namespace MidiToKeyboard.Keyborad.PressKey
{
    public class PressKeyByWinRing0 : IPressKey
    {
        public bool Initialize(EnumWindowsType winType)
        {
            return WinRing0.init();
        }

        public void KeyDown(EnumKey key)
        {
            WinRing0.KeyDown(key);//按下
        }

        public void KeyPress(EnumKey key, double milliseconds)
        {
            KeyDown(key);//按下
            Thread.Sleep((int)milliseconds);
          
            KeyUp(key);//松开
        }

        public void KeyUp(EnumKey key)
        {
            WinRing0.KeyUp(key);//松开
        }
    }
}
