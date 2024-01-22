using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.MusicTheory;
using Melanchall.DryWetMidi.Tools;
using MidiToKeyboard.Midi.Entity;
using MidiToKeyboard.Midi.Util;
using Note = Melanchall.DryWetMidi.Interaction.Note;

namespace MidiToKeyboard.Midi.MidiSong
{
    public class Song
    {

        /// <summary>
        /// Midi文件
        /// </summary>
        public MidiFile MidiFile { get; }
        /// <summary>
        /// 节奏表
        /// </summary>
        public TempoMap TempoMap { get; }
        /// <summary>
        /// 所有的midi事件
        /// </summary>
        public List<TimedEvent> TimedEvents { get; }
        /// <summary>
        /// 配置
        /// </summary>
        public SongConfig Config { get; }
        /// <summary>
        /// 偏移值
        /// </summary>
        public int Shifting { get; }

        /// <summary>
        /// 获取Midi播放器
        /// </summary>
        /// <returns></returns>
        public Playback GetPlay()
        {
            return MidiFile.GetPlayback();
        }
        public Song(string midiPath)
        {
            Config = SongConfig.UseDefaultConfig();
            MidiFile = MidiFile.Read(midiPath);
            TempoMap = MidiFile.GetTempoMap();
            TimedEvents = MidiFile.GetTimedEvents().ToList();
            MidiFile.GetNotes();
            //获取最佳偏移值
            Shifting = ComputeBestShift();

        }
        public Song(string midiPath, SongConfig songConfig)
        {
            Config = songConfig;
            MidiFile = MidiFile.Read(midiPath);
            TempoMap = MidiFile.GetTempoMap();
            TimedEvents = MidiFile.GetTimedEvents().ToList();
            MidiFile.GetNotes();
            //获取最佳偏移值
            Shifting = ComputeBestShift();

        }

        /// <summary>
        /// 计算最佳偏移值
        /// </summary>
        /// <returns></returns>
        public int ComputeBestShift()
        {
            int octave_interval = Config.OctaveInterval;
            string keytable = Config.Keytable;
            int[] note_counter = new int[octave_interval];
            int[] octave_list = new int[11];

            foreach (var midiEvent in TimedEvents)
            {
                //不能演奏直接跳过
                if (!NoteUtil.IsCanPlayable(midiEvent.Event))
                {
                    continue;
                }
                var midiKey = midiEvent.Event as NoteOnEvent;
                if (midiKey == null) continue;
                for (int i = 0; i < octave_interval; i++)
                {
                    int note_pitch = (midiKey.NoteNumber + i) % octave_interval;
                    if (keytable[note_pitch] != '?')
                    {
                        note_counter[i]++;
                        int note_octave = (midiKey.NoteNumber + i) / octave_interval;
                        octave_list[note_octave]++;
                    }
                }
            }

            int max_note = Array.IndexOf(note_counter, note_counter.Max());
            int shifting = 0;
            int counter = 0;

            for (int i = 0; i < octave_list.Length - 3; i++)
            {
                int amount = octave_list.Skip(i).Take(3).Sum();

                if (amount > counter)
                {
                    counter = amount;
                    shifting = i;
                }
            }

            return max_note + (4 - shifting) * octave_interval;
        }
        /// <summary>
        /// 计算键盘按键
        /// </summary>
        /// <param name="noteKey"></param>
        /// <param name="time"></param>
        /// <param name="length"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public NoteKeyboard? GetKeyboardKey(NotePlaybackData noteKey, long time,long length)
        {
            int shifting = Shifting;
            int octave_interval = Config.OctaveInterval;
            string keytable = Config.Keytable;
            int c3_pitch = Config.C3Pitch;
            int c5_pitch = Config.C5Pitch;
            int b5_pitch = Config.B5Pitch;
            try
            {
                int pitch = noteKey.NoteNumber + shifting;
                int original_pitch = pitch;
                if (pitch < c3_pitch)
                    pitch = pitch % octave_interval + c3_pitch;
                else if (pitch > b5_pitch)
                    pitch = pitch % octave_interval + c5_pitch;

                //获取音符
                var originalNote = new Note(new SevenBitNumber((byte)original_pitch), length, time);
                var pitchNote = new Note(new SevenBitNumber((byte)pitch), length, time);

                if (pitch < c3_pitch || pitch > b5_pitch)
                {
                    Debug.WriteLine("超出音域，跳过这个音符");
                    return null;
                }

                char key_press = char.ToUpper(keytable[pitch - c3_pitch]);
                //处理按下耗时
                MetricTimeSpan metricTime = TimeConverter.ConvertTo<MetricTimeSpan>(length, TempoMap);

                Debug.WriteLine($"原始: {originalNote}({original_pitch}) 播放音符: {pitchNote}({pitch}) 按下: {key_press},时间:{length}");
                return new NoteKeyboard(pitchNote,key_press, length);
            }
           
            catch (Exception)
            {

                return null;
            }

            return null;
        }
 

    }
}
