﻿using MidiToKeyBoard.Core.Constant;
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
                      EnumKey.Z,EnumKey.S,EnumKey.X,EnumKey.D,EnumKey.C,EnumKey.V,EnumKey.G,EnumKey.B,EnumKey.H,EnumKey.N,EnumKey.J,EnumKey.M
                  }  ,
                  new ()
                  {
                      EnumKey.Oemcomma,EnumKey.L,EnumKey.OemPeriod,EnumKey.OemSemicolon,EnumKey.OemQuestion,EnumKey.Q,EnumKey.D2,EnumKey.W,EnumKey.D3,EnumKey.E,EnumKey.D4,EnumKey.R
                  },
                  new ()
                  {
                      EnumKey.T,EnumKey.D6,EnumKey.Y,EnumKey.D7,EnumKey.U,EnumKey.I,EnumKey.D9,EnumKey.O,EnumKey.D0,EnumKey.P,EnumKey.OemMinus,EnumKey.OemCloseBrackets
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
