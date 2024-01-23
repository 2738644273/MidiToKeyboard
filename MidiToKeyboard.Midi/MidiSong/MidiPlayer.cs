using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using MidiToKeyboard.Keyborad.PressKey;
using MidiToKeyboard.Midi.Entity;

namespace MidiToKeyboard.Midi.MidiSong
{
    /// <summary>
    /// 演奏器
    /// </summary>
    public class MidiPlayer
    {
        public event Action<NoteKeyboard> OnPlayKey;
        public Playback Playback { get; }
        public Song Song { get; }

        private OutputDevice OutputDevice { get;}
        /// <summary>
        /// 演奏器类
        /// </summary>
        /// <param name="song">要播放的歌曲</param>
        /// <param name="pressKey">按键键盘接口</param>
        /// <param name="outputAudio">输出到音频</param>
        public MidiPlayer(Song song, OutputDevice outputAudio = null)
        {
            Song = song;
            Playback = song.GetPlay();
            if (outputAudio is not null)
            {
                OutputDevice = outputAudio;
                Playback.OutputDevice = OutputDevice;
            }
          
            Playback.NoteCallback = NoteHandler;
        }
 
        /// <summary>
        /// 音符处理器
        /// </summary>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <param name="length"></param>
        /// <param name="playbackTime"></param>
        /// <returns></returns>
        private NotePlaybackData NoteHandler(NotePlaybackData data, long time, long length, TimeSpan playbackTime)
        {
            Song.PlaybackProgressTime = Playback.GetCurrentTime<MetricTimeSpan>();
            var originalNote = (int)data.NoteNumber;
            var modifiedToneKey = originalNote + Song.ModifiedTone;
            //转换后音调
            var newNotePlayBackData = new NotePlaybackData(new SevenBitNumber((byte)modifiedToneKey), data.Velocity, data.OffVelocity, data.Channel);
            //转换成按键
            NoteKeyboard? noteKeyboard = Song.GetKeyboardKey(newNotePlayBackData, time, length);
            
            if (noteKeyboard is object)
            {
                OnPlayKey?.Invoke(noteKeyboard);
                //PressKey.KeyPress(noteKeyboard.Key, (int)0);
            }
            return newNotePlayBackData;
        }
        /// <summary>
        /// 开始播放
        /// </summary>
        public void Play()
        {
 
            //设置曲速
            Playback.Speed = Song.Speed;
            Playback.Start();
            Playback.MoveToTime(Song.PlaybackProgressTime);
        }
        /// <summary>
        /// 暂停
        /// </summary>
        public void Stop()
        {
            Playback.Stop();
        }
        public void Dispose()
        {
            Playback?.Dispose();
        }
    }
}
