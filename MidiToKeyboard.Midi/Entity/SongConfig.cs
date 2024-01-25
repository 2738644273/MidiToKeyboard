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
                      EnumKey.Z,EnumKey.None,EnumKey.X,EnumKey.None,EnumKey.C,EnumKey.V,EnumKey.None,EnumKey.B,EnumKey.None,EnumKey.N,EnumKey.None,EnumKey.M
                  }  ,
                  new ()
                  {
                      EnumKey.A,EnumKey.None,EnumKey.S,EnumKey.None,EnumKey.D,EnumKey.F,EnumKey.None,EnumKey.G,EnumKey.None,EnumKey.H,EnumKey.None,EnumKey.J
                  },
                  new ()
                  {
                      EnumKey.Q,EnumKey.None,EnumKey.W,EnumKey.None,EnumKey.E,EnumKey.R,EnumKey.None,EnumKey.T,EnumKey.None,EnumKey.Y,EnumKey.None,EnumKey.U
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
