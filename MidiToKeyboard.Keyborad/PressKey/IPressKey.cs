using MidiToKeyBoard.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidiToKeyboard.Keyborad.PressKey
{
  public  interface IPressKey
    {
        bool Initialize(EnumWindowsType winType);

        Task KeyPress(EnumKey key,double milliseconds);

        void KeyDown(EnumKey key);

        void KeyUp(EnumKey key);
    }
}
