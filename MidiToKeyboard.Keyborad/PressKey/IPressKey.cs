using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidiToKeyboard.Keyborad.PressKey
{
  public  interface IPressKey
    {
        bool Initialize(EnumWindowsType winType);

        Task KeyPress(char key,int milliseconds);

        void KeyDown(char key);

        void KeyUp(char key);
    }
}
