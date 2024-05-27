using MidiToKeyBoard.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace MidiToKeyboard.Midi.Entity
{
    public class SongConfig
    {
        /// <summary>
        /// 按键映射表
        /// </summary>
        public List<List<EnumKey>> KeyTable { get; set; } 
        /// <summary>
        /// C3音高---可演奏的最低音域限制，也用作基准音C3  C3 到 C5 之间的音符号码降低或升高到这个范围
        /// </summary>
        public int C3Pitch { get; set; }
        /// <summary>
        /// C5音高---用作基准音C5  C3 到 C5 之间的音符号码降低或升高到这个范围
        /// </summary>
        public int C5Pitch { get; set; }
        /// <summary>
        /// B5音高---可演奏的最高音限制
        /// </summary>
        public int B5Pitch { get; set; }
    

        /// <summary>
        /// 八度音程
        /// </summary>
        public int OctaveInterval = 12;
        public static SongConfig UseDefaultConfig()
        {
            return new SongConfig()
            {
                //半音没有对应的按键。使用None不做任何处理
                KeyTable = new ()
                {
                  new ()
                  {
                      EnumKey.VK_Z,EnumKey.VK_S,EnumKey.VK_X,EnumKey.VK_D,EnumKey.VK_C,EnumKey.VK_V,EnumKey.VK_G,EnumKey.VK_B,EnumKey.VK_H,EnumKey.VK_N,EnumKey.VK_J,EnumKey.VK_M
                  }  ,
                  new ()
                  {
                      EnumKey.OEM_COMMA,EnumKey.VK_L,EnumKey.OEM_PERIOD,EnumKey.OEM_1,EnumKey.OEM_2,EnumKey.VK_Q,EnumKey.NUMPAD3,EnumKey.VK_W,EnumKey.NUMPAD3,EnumKey.VK_E,EnumKey.NUMPAD4,EnumKey.VK_R
                  },
                  new ()
                  {
                      EnumKey.VK_T,EnumKey.NUMPAD6,EnumKey.VK_Y,EnumKey.NUMPAD7,EnumKey.VK_U,EnumKey.VK_I,EnumKey.NUMPAD9,EnumKey.VK_O,EnumKey.NUMPAD0,EnumKey.VK_P,EnumKey.OEM_MINUS,EnumKey.OEM_6
                  }
                },
               //Keytable = "z?x?cv?b?n?m" + "a?s?df?g?h?j" + "q?w?er?t?y?u",
                C3Pitch = 48,
                C5Pitch = 72,
                B5Pitch = 83,
            };
        }
    }
}
