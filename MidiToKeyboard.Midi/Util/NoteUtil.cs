using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using MidiToKeyboard.Midi.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MidiToKeyboard.Midi.Util
{
    /// <summary>
    /// 音符工具
    /// </summary>
    public static class NoteUtil
    {
        /// <summary>
        /// 能否演奏的音符
        /// </summary>
        /// <param name="midiEvent">midi事件</param>
        /// <returns>true可以演奏的符号，false不能演奏的符号</returns>
        public static   bool IsCanPlayable(MidiEvent midiEvent)
        {
            if (midiEvent.EventType == MidiEventType.NoteOn)
            {
                return true;
            }
            return false;
        }
       
       
    }
}
