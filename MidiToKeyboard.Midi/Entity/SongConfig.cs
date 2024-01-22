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
        public string Keytable { get; set; }
        /// <summary>
        /// C3音高
        /// </summary>
        public int C3Pitch { get; set; }
        /// <summary>
        /// C5音高
        /// </summary>
        public int C5Pitch { get; set; }
        /// <summary>
        /// B5音高
        /// </summary>
        public int B5Pitch { get; set; }
    

        /// <summary>
        /// 八度音程
        /// </summary>
        public int OctaveInterval { get; } = 12;
        public static SongConfig UseDefaultConfig()
        {
            return new SongConfig()
            {
      
                Keytable = "z?x?cv?b?n?m" + "a?s?df?g?h?j" + "q?w?er?t?y?u",
                C3Pitch = 48,
                C5Pitch = 72,
                B5Pitch = 83,
            };
        }
    }
}
