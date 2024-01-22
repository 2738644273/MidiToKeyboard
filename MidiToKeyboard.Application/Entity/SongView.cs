using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidiToKeyboard.Midi.MidiSong;

namespace MidiToKeyboard.Application.Entity
{
    public class SongView
    {
        public SongView(string filePath)
        {
            Song = new Song(filePath);
            SongName = Path.GetFileName(filePath);
            Guid = new Guid();
        }
        public Song Song { get; set; }
        public string SongName { get; set; }
        public Guid Guid { get; }
    }
}
