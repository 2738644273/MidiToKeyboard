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
                KeyTable = new()
                {
                  new ()
                  {
                      EnumKey.VK_Z,EnumKey.None,EnumKey.VK_X,EnumKey.None,EnumKey.VK_C,EnumKey.VK_V,EnumKey.None,EnumKey.VK_B,EnumKey.None,EnumKey.VK_N,EnumKey.None,EnumKey.VK_M
                  }  ,
                  new ()
                  {
                      EnumKey.VK_A,EnumKey.None,EnumKey.VK_S,EnumKey.None,EnumKey.VK_D,EnumKey.VK_F,EnumKey.None,EnumKey.VK_G,EnumKey.None,EnumKey.VK_H,EnumKey.None,EnumKey.VK_J
                  },
                  new ()
                  {
                      EnumKey.VK_Q,EnumKey.None,EnumKey.VK_W,EnumKey.None,EnumKey.VK_E,EnumKey.VK_R,EnumKey.None,EnumKey.VK_T,EnumKey.None,EnumKey.VK_Y,EnumKey.None,EnumKey.VK_U
                  }
                },
                //Keytable = "z?x?cv?b?n?m" + "a?s?df?g?h?j" + "q?w?er?t?y?u",
                C3Pitch = 48,
                C5Pitch = 72,
                B5Pitch = 83,
            };
        }
        public static SongConfig UseDFConfig()
        {
            return new SongConfig()
            {
                //半音没有对应的按键。使用None不做任何处理
                KeyTable = new()
                {
                  new ()
                  {
                      EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F
                  }  ,
                  new ()
                  {
                      EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F,EnumKey.VK_F
                  },
                  new ()
                  {
                      EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D,EnumKey.VK_D
                  }
                },
                //Keytable = "z?x?cv?b?n?m" + "a?s?df?g?h?j" + "q?w?er?t?y?u",
                C3Pitch = 48,
                C5Pitch = 72,
                B5Pitch = 83,
            };
        }

        public static SongConfig UseDetailConfig()
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
                      EnumKey.OEM_COMMA,EnumKey.VK_L,EnumKey.OEM_PERIOD,EnumKey.OEM_1,EnumKey.OEM_2,EnumKey.VK_Q,EnumKey.VK_2,EnumKey.VK_W,EnumKey.VK_3,EnumKey.VK_E,EnumKey.VK_4,EnumKey.VK_R
                  },
                  new ()
                  {
                      EnumKey.VK_T,EnumKey.VK_6,EnumKey.VK_Y,EnumKey.VK_7,EnumKey.VK_U,EnumKey.VK_I,EnumKey.VK_9,EnumKey.VK_O,EnumKey.VK_0,EnumKey.VK_P,EnumKey.OEM_MINUS,EnumKey.OEM_4
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
