﻿using System;
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
            FileName = Path.GetFileName(filePath);
            FilePath = filePath;
        }
        public Song Song { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; }
    }
}