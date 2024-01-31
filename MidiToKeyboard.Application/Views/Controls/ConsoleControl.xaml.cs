using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using MidiToKeyboard.App.Events;
using MidiToKeyboard.App.Models;
using MidiToKeyboard.App.ViewModels;
using MidiToKeyboard.Midi.MidiSong;
using Prism.Events;

namespace MidiToKeyboard.App.Views.Controls
{
    /// <summary>
    /// ConsoleControl.xaml 的交互逻辑
    /// </summary>
    public partial class ConsoleControl
    {
        private readonly ConsoleControlViewModel _consoleControlViewModel;
        private readonly IEventAggregator _eventAggregator;
        private MidiModel _midiModel;
        private MidiPlayer _midiPlayer;
        public ConsoleControl(ConsoleControlViewModel consoleControlViewModel,IEventAggregator eventAggregator)
        {
            InitializeComponent();
            DataContext = consoleControlViewModel;
            _consoleControlViewModel = consoleControlViewModel;
            _eventAggregator = eventAggregator;
        }

        private void ConsoleControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<ToPlayMidiEvent>().Subscribe(PlayMidi);
        }
        OutputDevice OTP = OutputDevice.GetByIndex(0);
        private void PlayMidi(MidiModel obj)
        {
            if (obj is object)
            {
                //初始化播放器
                _midiPlayer = new MidiPlayer(obj.Song, OTP);
                _midiModel = obj;
                //设定总时长
                _consoleControlViewModel.ProcessorMaxValue = _midiPlayer.TotalTime.TotalMilliseconds;
                _midiPlayer.Playback.EventPlayed += (sender, e) =>
                {
                    //设定当前播放的毫秒
                    _consoleControlViewModel.ProcessorCurrentValue = _midiPlayer.PlaybackProgressTime.TotalMilliseconds;
                };
              
            }
            
        }

 

        private void ConsoleControl_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<ToPlayMidiEvent>().Unsubscribe(PlayMidi);
        }

        private void OnStartOrStopClick(object sender, MouseButtonEventArgs e)
        {
            if (_midiModel is null)
            {
                return;
            }
            if (_consoleControlViewModel.IsPlay)
            {
                _midiPlayer.Play();
            }
            else
            {
                _midiPlayer.Stop();
            }
            _consoleControlViewModel.IsPlay = !_consoleControlViewModel.IsPlay;
           
        }
 
    }
}
