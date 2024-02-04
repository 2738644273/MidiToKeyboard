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
using MidiToKeyboard.App.Events;
using MidiToKeyboard.App.Models;
using MidiToKeyboard.App.ViewModels;

namespace MidiToKeyboard.App.Views.Controls
{
    /// <summary>
    /// OperatingStationControl.xaml 的交互逻辑
    /// </summary>
    public partial class OperatingStationControl
    {
        private readonly OperatingStationControlViewModel _operatingStationControlViewModel;
        private readonly IEventAggregator _eventAggregator;
        private  MidiModel _midiModel;
        public OperatingStationControl(OperatingStationControlViewModel operatingStationControlViewModel,IEventAggregator eventAggregator)
        {
            InitializeComponent();
            DataContext = operatingStationControlViewModel;
            _operatingStationControlViewModel = operatingStationControlViewModel;
            _eventAggregator = eventAggregator;
        }

        private void LoadMidi(MidiModel midiModel)
        {
            _midiModel = midiModel;
        }
        private void OperatingStationControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<ToPlayMidiEvent>().Subscribe(LoadMidi);
        }

        private void OperatingStationControl_OnUnloaded(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<ToPlayMidiEvent>().Unsubscribe(LoadMidi);
        }
    }
}
