using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Interaction;
using MidiToKeyboard.Midi.MidiSong;

namespace MidiToKeyboard.Application.Entity
{
    public class SongView
    {
        public SongView(string filePath,bool f)
        {
            Song = new Song(filePath, f);
            FileName = Path.GetFileName(filePath);
            FilePath = filePath;
        }
        public Song Song { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; }

        public MetricTimeSpan MetricTimeSpan { get; set; } = new MetricTimeSpan(0);
    }
}
