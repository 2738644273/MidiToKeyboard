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
using MidiToKeyboard.Application.ViewModel;
using MidiToKeyboard.Application.Entity;

namespace MidiToKeyboard.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MidiPlayer midiPlayer = null;
        private static IPressKey mPressKey = new PressKeyByWinRing0();
        private MainWindowViewModel MainWindowViewModel { get;  }
        public MainWindow()
        {
            InitializeComponent();
            //初始化按键
            mPressKey.Initialize(EnumWindowsType.Win32);
            MainWindowViewModel = new MainWindowViewModel();
            DataContext = MainWindowViewModel;
        }
 
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (midiPlayer is null) {
                System.Windows.MessageBox.Show("没有选择任何曲目");
            }
            midiPlayer.ModifiedTone = Convert.ToInt32(ModifiedToneTextBox.Text);
            midiPlayer.Speed = Convert.ToDouble(SpeedTextBox.Text);
            midiPlayer.Play();
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            midiPlayer.Stop();
        }

       
        /// <summary>
        /// 选择后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                midiPlayer?.Dispose();
                var listbox = e.Source as System.Windows.Controls.ListBox;
                var data = listbox.SelectedItem as SongView;
                
                midiPlayer = new MidiPlayer(data.Song, mPressKey, true);

            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Mid文件 (*.mid)|*.mid|Midi文件 (*.midi)|*.midi";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MainWindowViewModel.SongList.Any(p => p.FileName == openFileDialog.FileName))
                {
                    System.Windows.MessageBox.Show("文件已存在播放列表");
                }
                var songView  =  new SongView(openFileDialog.FileName); 
                MainWindowViewModel.SongList.Add(songView);
            }

  
        }
    }
}