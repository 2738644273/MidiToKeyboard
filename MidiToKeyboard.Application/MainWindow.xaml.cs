using MidiToKeyboard.Keyborad.PressKey;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using MidiToKeyboard.Midi.Entity;
using MidiToKeyboard.Midi.MidiSong;
using MidiToKeyboard.Midi.Util;

namespace MidiToKeyboard.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MidiPlayer midiPlayer = null;
        static IPressKey mPressKey = new PressKeyByWinRing0();
        
        public MainWindow()
        {
            InitializeComponent();
            //初始化按键
            mPressKey.Initialize(EnumWindowsType.Win32);
 
        }
 
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            midiPlayer.ModifiedTone = Convert.ToInt32(ModifiedToneTextBox.Text);
            midiPlayer.Speed = Convert.ToDouble(SpeedTextBox.Text);
            midiPlayer.Play();
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            midiPlayer.Stop();
        }

        private void FilePathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FilePathTextBox.Text))
                {
                    return;
                }
                var song = new Song(FilePathTextBox.Text);
                midiPlayer = new MidiPlayer(song, mPressKey, false);

            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}