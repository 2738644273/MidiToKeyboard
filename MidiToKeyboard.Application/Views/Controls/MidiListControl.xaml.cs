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
using Prism.Events;
using Wpf.Ui.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Vanara.PInvoke.Kernel32;
using ListView = System.Windows.Controls.ListView;
using MessageBox = System.Windows.MessageBox;

namespace MidiToKeyboard.App.Views.Controls
{
    /// <summary>
    /// MidiListControl.xaml 的交互逻辑
    /// </summary>
    public partial class MidiListControl
    {
        public readonly MidiListControlViewModel _midiListControlViewModel;
        public readonly IEventAggregator _aggregator;
        public MidiListControl(MidiListControlViewModel midiListControlViewModel, IEventAggregator aggregator)
        {
            InitializeComponent();
            _midiListControlViewModel=midiListControlViewModel;
            _aggregator = aggregator;
            DataContext = midiListControlViewModel;
            midiListControlViewModel.MidiModels.Add(new MidiModel("C:\\Users\\Lenovo\\Desktop\\songs\\dazkj.mid"));
            midiListControlViewModel.MidiModels.Add(new MidiModel("C:\\Users\\Lenovo\\Desktop\\songs\\xxdty.mid"));
        }


     
        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listView = (ListView)sender;
            var currentMidis = listView.SelectedItem as MidiModel;
            if (currentMidis == null)
            {
                MessageBox.Show("选择的midi歌曲不存在");
                return;
            }
            _aggregator.GetEvent<ToPlayMidiEvent>().Publish(currentMidis);

        }
    }
}
