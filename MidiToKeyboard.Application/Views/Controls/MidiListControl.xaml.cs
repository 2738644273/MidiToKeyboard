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
using MidiToKeyboard.App.Models;
using MidiToKeyboard.App.ViewModels;
using Wpf.Ui.Controls;

namespace MidiToKeyboard.App.Views.Controls
{
    /// <summary>
    /// MidiListControl.xaml 的交互逻辑
    /// </summary>
    public partial class MidiListControl
    {
        public readonly MidiListControlViewModel _midiListControlViewModel;
        public MidiListControl(MidiListControlViewModel midiListControlViewModel)
        {
            InitializeComponent();
            _midiListControlViewModel=midiListControlViewModel;
            DataContext = midiListControlViewModel;
            midiListControlViewModel.MidiModels.Add(new MidiModel("C:\\Users\\Lenovo\\Desktop\\songs\\wwhm.mid"));
        }
    }
}
