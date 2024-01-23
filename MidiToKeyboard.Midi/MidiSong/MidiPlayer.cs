using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using MidiToKeyboard.Keyborad.PressKey;
using MidiToKeyboard.Midi.Entity;

namespace MidiToKeyboard.Midi.MidiSong
{
    /// <summary>
    /// 演奏器
    /// </summary>
    public class MidiPlayer : IDisposable
    {
        public Playback Playback { get; }
        public Song Song { get; }
        private IPressKey PressKey { get; }
        public int ModifiedTone { get; set; } = 0;
        public double Speed { get; set; } = 1d;
        private OutputDevice OutputDevice { get;}
        public MidiPlayer(Song song, IPressKey pressKey, OutputDevice outputAudio)
        {
            Song = song;
            Playback = song.GetPlay();
            if (outputAudio is not null)
            {
                OutputDevice = outputAudio;
                Playback.OutputDevice =OutputDevice;
            }
            PressKey = pressKey;
            Playback.NoteCallback = NoteHandler;
        }

        private NotePlaybackData NoteHandler(NotePlaybackData data, long time, long length, TimeSpan playbackTime)
        {
            var originalNote = (int)data.NoteNumber;
            var modifiedToneKey = originalNote + ModifiedTone;
            //转换后音调
            var newNotePlayBackData = new NotePlaybackData(new SevenBitNumber((byte)modifiedToneKey), data.Velocity, data.OffVelocity, data.Channel);
            //转换成按键
            NoteKeyboard? noteKeyboard = Song.GetKeyboardKey(newNotePlayBackData, time, length);
    
            if (noteKeyboard is object)
            {
               // PressKey.KeyPress(noteKeyboard.Key, (int)0);
            }
            return newNotePlayBackData;

        }

        public void Play()
        {
            Playback.Speed = Speed;
            Playback.Start();
        }

        public void Stop()
        {
            Playback.Stop();
        }
        public void Dispose()
        {
            OutputDevice?.Dispose();
            Playback?.Dispose();
        }
    }
}
