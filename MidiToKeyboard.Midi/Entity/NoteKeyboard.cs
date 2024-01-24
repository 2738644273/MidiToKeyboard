using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Interaction;

namespace MidiToKeyboard.Midi.Entity
{
    public class NoteKeyboard
    {
        /// <summary>
        /// 压下的键
        /// </summary>
        public char Key { get;}
        /// <summary>
        /// 按下的毫秒数
        /// </summary>
        public long Millisecond { get;  }
        /// <summary>
        /// 转换后的音符
        /// </summary>
        public Note NewNote { get;}
        /// <summary>
        /// 原始音符
        /// </summary>
        public Note OldNote { get;}
        public NoteKeyboard(Note newNote, Note oldNote,char key, long millisecond)
        {
            Key = key;
            Millisecond = millisecond;
            NewNote = newNote;
            OldNote = oldNote;
        }
    }
}
