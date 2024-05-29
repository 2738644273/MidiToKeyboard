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
using MidiToKeyboard.Keyborad.HotKey;
using Wpf.Ui.Controls;
using MidiToKeyboard.Keyborad.HotkeyCapture;
using Vanara.PInvoke;
using Wpf.Ui.Interop.WinDef;
using System.Diagnostics;
using System.Linq;
using MidiToKeyBoard.Core.Constant;
using TestKeyboard.PressKey;
using static Vanara.PInvoke.Gdi32;
using MidiToKeyboard.Net;
using System.ComponentModel;
using MidiToKeyboard.Net.Server;
using System.Net;
using MidiToKeyboard.Net.Client;
using Prism;
using System.Runtime.InteropServices;

namespace MidiToKeyboard.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FluentWindow
    {
        private static MidiPlayer midiPlayer = null;
        private static IPressKey mPressKey = new PressKeyBySendInput();
        private static OutputDevice OutputDevice = null;
        private static SongView currentSongView = null;
        private static HotkeyHook KeyBindInfo = null;
        private static bool isStart = false;
        public static bool PlayPP = false;
        public static bool PlayMaster = false;
        private MainWindowViewModel MainWindowViewModel { get; }
        public MainWindow()
        {
            InitializeComponent();
            //初始化按键
            mPressKey.Initialize(EnumWindowsType.Win64);
            MainWindowViewModel = new MainWindowViewModel();
            DataContext = MainWindowViewModel;

            #region 热键注册

            Hotkey hotkey12 = new(HotKey.FromString("Ctrl + F12").ToString());
            Hotkey hotkey11 = new(HotKey.FromString("Ctrl + F11").ToString());
            Hotkey hotkey10 = new(HotKey.FromString("Ctrl + F10").ToString());

            KeyBindInfo = new HotkeyHook();
            KeyBindInfo.KeyPressed += KeyBindInfo_KeyPressed;
            KeyBindInfo.RegisterHotKey(hotkey10.ModifierKey, hotkey12.Key);
            KeyBindInfo.RegisterHotKey(hotkey10.ModifierKey, hotkey10.Key);
            KeyBindInfo.RegisterHotKey(hotkey11.ModifierKey, hotkey11.Key);

            #endregion
        }

        private void KeyBindInfo_KeyPressed(object? sender, KeyPressedEventArgs e)
        {
            SongView songView = null;


            //暂停
            if (e.Key == EnumKey.F11 && e.Modifier == User32.HotKeyModifiers.MOD_CONTROL)
            {

                if (currentSongView is null)
                {
                    return;
                }

                if (isStart)
                {
                    Stop();
                }
                else
                {

                    midiPlayer = Start(currentSongView);
                }
                return;
            }
            //上一首
            if (e.Key == EnumKey.F10 && e.Modifier == User32.HotKeyModifiers.MOD_CONTROL)
            {

                songView = GetSong(-1);

            }

            //下一首
            if (e.Key == EnumKey.F12 && e.Modifier == User32.HotKeyModifiers.MOD_CONTROL)
            {

                songView = GetSong(1);

            }

            if (songView is object)
            {

                midiPlayer = Start(songView);
            }


        }

        private SongView GetSong(int ii)
        {
            var selectI = SongListBox.SelectedIndex;
            var allCount = MainWindowViewModel.SongList.Count;
            var nextValue = selectI + ii;
            if (selectI == -1)
            {
                if (allCount > 0)
                {
                    nextValue = 0;
                }
            };

            if (nextValue >= 0 && nextValue < allCount)
            {
                SongListBox.SelectedIndex = nextValue;
                var song = SongListBox.SelectedItem as SongView;
                if (song != null)
                {
                    return song;
                }
            }

            return null;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (currentSongView is null)
            {
                SongConfig a;
                if (PlayMaster)
                {
                    a = SongConfig.UseDetailConfig();
                }
                else
                {
                    a = SongConfig.UseDefaultConfig();
                }

                foreach (var items in a.KeyTable)
                {
                    foreach (var item in items)
                    {

                        await mPressKey.KeyPress(item, 150);
                    }
                }
                a.KeyTable.Reverse();
                foreach (var items in a.KeyTable)
                {
                    items.Reverse();
                    foreach (var item in items)
                    {

                        await mPressKey.KeyPress(item, 150);
                    }
                }

                return;

            }

            if (SocketService != null)
            {
                this.logInfo.Text += "检测到其他客户端的链接，发送协同播放命令\r\n";
                SocketService.Multicast("play");
            }
            midiPlayer = Start(currentSongView);
        }

        private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
        {
            if (SocketService != null)
            {
                this.logInfo.Text += "检测到其他客户端的链接，发送协同停止命令\r\n";
                SocketService.Multicast("stop");
            }
            Stop();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            SocketService?.DisconnectAll();
            SocketService?.Dispose();

            SocketClient?.Disconnect();
            SocketClient?.Dispose();
        }
        private MidiPlayer Start(SongView songView = null)
        {
            if (songView is null)
            {
                songView = GetSong(1);
            }
            logInfo.Text = "";
            logInfo.Text += $"切歌:{songView?.FileName}-------------------------------";

            midiPlayer?.Dispose();
            OutputDevice?.Dispose();
            GC.Collect();
            GC.SuppressFinalize(this);
            songView.Song.ModifiedTone = Convert.ToInt32(ModifiedToneTextBox.Text);
            songView.Song.Speed = Convert.ToDouble(SpeedTextBox.Text);

            OutputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth");
            isStart = true;
            var midi = new MidiPlayer(songView.Song, null);
            midi.PlaybackProgressTime = songView.MetricTimeSpan;
            midi.OnPlay += Midi_OnPlayKey;
            slide.Minimum = 0;
            slide.Maximum = songView.Song.MidiFile.GetDuration<MetricTimeSpan>().TotalSeconds;
            slide.Value = songView.MetricTimeSpan.TotalSeconds;
            midi.Playback.EventPlayed += (object? sender, MidiEventPlayedEventArgs e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    slide.Value = songView.MetricTimeSpan.TotalSeconds;
                });
                songView.MetricTimeSpan = midi.PlaybackProgressTime;
            };
            midiPlayer = midi;
            midiPlayer.Play();
            return midiPlayer;
        }


        private async Task Midi_OnPlayKey(NoteKeyboard obj)
        {

            try
            {
                string info = $"\n\r原始: {obj.OldNote}({obj.OldNote.NoteName}) 播放音符: {obj.NewNote}({obj.NewNote.NoteName}) 按下: {obj.Key},时间:{obj.Millisecond}";
                Debug.WriteLine(info);

                if (obj.Key != EnumKey.None)
                {

                    if (PlayPP)
                    {
                        await Task.Run(() =>
                        {
                            mPressKey.KeyPress(obj.Key, 0);
                        });
                    }
                    else
                    {

                      await  mPressKey.KeyPress(obj.Key, obj.Millisecond);

                    }


                }

            }
            catch (Exception exception)
            {


            }
        }

        private void Stop()
        {
            if (currentSongView is null)
            {
                return;
            }
            isStart = false;

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


                var listbox = e.Source as System.Windows.Controls.ListBox;
                currentSongView = listbox.SelectedItem as SongView;
                midiPlayer = Start(currentSongView);

            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "MIDI 文件 (*.mid;*.midi)|*.mid;*.midi|所有文件 (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    if (MainWindowViewModel.SongList.Any(p => p.FileName == file))
                    {
                        continue;
                    }
                    var songView = new SongView(file, !PlayMaster);
                    MainWindowViewModel.SongList.Add(songView);
                }

            }
        }
        ClientCore SocketClient { get; set; }
        ServerCore SocketService { get; set; }
        private void connectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SocketClient is object)
            {
                SocketClient.Send("客户端发送了1");
            }
            if (!string.IsNullOrWhiteSpace(Ip.Text))
            {
                SocketClient = new ClientCore(Ip.Text, 8887);
                SocketClient.Connect();
                SocketClient.OnReceive = (str) =>
                {

                    Dispatcher.Invoke(new Action(() =>
                    {
                        this.logInfo.Text += str + "\r\n";
                        if (str == "play")
                        {
                            midiPlayer = Start(currentSongView);
                        }
                        else if (str == "stop")
                        {
                            Stop();
                        }
                    }));
                };
            }
        }

        private void createConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SocketService is object)
            {
                SocketService.Multicast("服务器发送测试1");
            }
            SocketService = new ServerCore(IPAddress.Any, 8887);
            SocketService.Start();
            try
            {
                SocketService.Multicast("发送测试1");
            }
            catch (Exception)
            {

                this.logInfo.Text = "没有客户端连接";
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PlayPP = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PlayPP = false;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            PlayMaster = true;
            var listbox = SongListBox;
            var list = listbox.ItemsSource.Cast<SongView>();
            foreach (var item in list)
            {
                item.Song.Config.KeyTable = SongConfig.UseDetailConfig().KeyTable;
            }
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            PlayMaster = false;
            var listbox = SongListBox;
            var list = listbox.ItemsSource.Cast<SongView>();
            foreach (var item in list)
            {
                item.Song.Config.KeyTable = SongConfig.UseDefaultConfig().KeyTable;
            }
        }

        private void slide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (currentSongView is object)
            {
                currentSongView.MetricTimeSpan = new MetricTimeSpan(TimeSpan.FromSeconds(slide.Value));
            }
        }
    }
}