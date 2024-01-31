using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;

using MidiToKeyboard.Midi.Entity;

namespace MidiToKeyboard.Midi.MidiSong
{
    /// <summary>
    /// 演奏器
    /// </summary>
    public class MidiPlayer
    {
        /// <summary>
        /// 演奏事件
        /// </summary>
        public event Action<NoteKeyboard> OnPlay;
        public Playback Playback { get; }
        /// <summary>
        /// Midi演奏对象
        /// </summary>
        public Song Song { get; }
        /// <summary>
        /// 输出到音频
        /// </summary>
        private OutputDevice OutputDevice { get; }

        /// <summary>
        /// 总计时间
        /// </summary>
        public MetricTimeSpan TotalTime  = new MetricTimeSpan(0);
        /// <summary>
        /// 播放进度
        /// </summary>
        public MetricTimeSpan PlaybackProgressTime { get; set; } = new (0);
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
            if (outputAudio != null)
            {
                OutputDevice = outputAudio;
                Playback.OutputDevice = OutputDevice;
            }
            TotalTime = Playback.GetDuration<MetricTimeSpan>();
            song.PlayingChannels = song.MidiFile.GetChannels().ToList();
            Playback.NotesPlaybackStarted += Playback_NotesPlaybackStarted;
            Playback.NoteCallback = NoteHandler;
    
            Playback.EventPlayed += (sender, args) =>
            {
                PlaybackProgressTime = Playback.GetCurrentTime<MetricTimeSpan>();
            };
        }
        /// <summary>
        /// 音符开始演奏时触发键盘转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Playback_NotesPlaybackStarted(object? sender, NotesEventArgs e)
        {
   
            foreach (var note in e.Notes)
            {
                //转换成按键
                NoteKeyboard? noteKeyboard = Song.GetKeyboardKey(note,Playback.TempoMap);
                if (noteKeyboard is not null && OnPlay is not null)
                {
                    OnPlay(noteKeyboard);
                }
            }

        }

        /// <summary>
        /// 音符处理器
        /// </summary>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <param name="length"></param>
        /// <param name="playbackTime"></param>
        /// <returns></returns>
        private NotePlaybackData? NoteHandler(NotePlaybackData data, long time, long length, TimeSpan playbackTime)
        {
            //通道列表存在该通道就播放，否则跳过该通道的所有音符
            if (Song.PlayingChannels.Contains(data.Channel))
            {
                var originalNote = (int)data.NoteNumber;
                var modifiedToneKey = originalNote + Song.ModifiedTone;
                //转换后音调
                var newNotePlayBackData = new NotePlaybackData(new SevenBitNumber((byte)modifiedToneKey), data.Velocity, data.OffVelocity, data.Channel);
                return newNotePlayBackData;
            }

            return null;
        }
 

        /// <summary>
        /// 开始播放
        /// </summary>
        public void Play()
        {

            //设置曲速
            Playback.Speed = Song.Speed;
            Playback.Start();
            Playback.MoveToTime(PlaybackProgressTime);
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
