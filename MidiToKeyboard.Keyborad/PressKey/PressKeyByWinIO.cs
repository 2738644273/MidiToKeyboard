﻿using MidiToKeyboard.Keyborad.PressKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using MidiToKeyboard.Keyborad.DriverStageHelper;


namespace MidiToKeyboard.Keyborad.PressKey
{
    public class PressKeyByWinIO : IPressKey
    {
        private EnumWindowsType mWinType;
        public bool Initialize(EnumWindowsType winType)
        {
            mWinType = winType;
            switch(mWinType)
            {
                case EnumWindowsType.Win64:
                    WinIO64.Initialize();
                    break;
                case EnumWindowsType.Win32:
                    WinIO32.Initialize();
                    break;
                default:
                    return false;
            }

            return true;
        }

        public void KeyDown(char key)
        {
            switch (mWinType)
            {
                case EnumWindowsType.Win64:
                    WinIO64.KeyDown((EnumKey)key);//按下
                    break;
                case EnumWindowsType.Win32:
                    WinIO32.KeyDown((EnumKey)key);//按下
                    break;
                default:
                    break;
            }
        }

        public async Task KeyPress(char key, int milliseconds)
        {
           
            KeyDown(key);
            await Task.Delay(TimeSpan.FromMilliseconds(milliseconds));
            KeyUp(key);
          
        }

        public void KeyUp(char key)
        {
            switch (mWinType)
            {
                case EnumWindowsType.Win64:
                    WinIO64.KeyUp((EnumKey)key);//按下
                    break;
                case EnumWindowsType.Win32:
                    WinIO32.KeyUp((EnumKey)key);//按下
                    break;
                default:
                    break;
            }
        }


        private static void Delay(int nMilliSeconds)
        {
          
            return;
        }
    }
}
