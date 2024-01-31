using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidiToKeyboard.App.Models;

namespace MidiToKeyboard.App.Events
{
 public   class ToPlayMidiEvent : PubSubEvent<MidiModel>
    {
    }
}
