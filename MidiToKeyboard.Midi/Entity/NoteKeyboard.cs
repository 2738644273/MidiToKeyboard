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
        public Note NewNote { get;}

        public NoteKeyboard(Note newNote,char key, long millisecond)
        {
            Key = key;
            Millisecond = millisecond;
            NewNote = newNote;

        }
    }
}
