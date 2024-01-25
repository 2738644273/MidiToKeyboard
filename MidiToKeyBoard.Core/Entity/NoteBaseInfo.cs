using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiToKeyBoard.Core.Entity
{
    public class NoteBaseInfo
    {
        public string NoteName { get; set; }

        public int MidiPitchVoice { get; set; }
    }
}
