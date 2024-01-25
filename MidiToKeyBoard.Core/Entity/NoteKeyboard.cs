using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidiToKeyBoard.Core.Constant;
using MidiToKeyBoard.Core.Entity;

namespace MidiToKeyboard.Midi.Entity
{
    public class NoteKeyboard
    {
        /// <summary>
        /// 压下的键
        /// </summary>
        public EnumKey Key { get;}
        /// <summary>
        /// 按下的毫秒数
        /// </summary>
        public double Millisecond { get;  }
        /// <summary>
        /// 转换后的音符
        /// </summary>
        public NoteBaseInfo NewNote { get;}
        /// <summary>
        /// 原始音符
        /// </summary>
        public NoteBaseInfo OldNote { get;}
        public NoteKeyboard(NoteBaseInfo newNote, NoteBaseInfo oldNote, EnumKey key, double millisecond)
        {
            NewNote = newNote;
            OldNote = oldNote;
            Key = key;
            Millisecond = millisecond;

        }
    }
}
