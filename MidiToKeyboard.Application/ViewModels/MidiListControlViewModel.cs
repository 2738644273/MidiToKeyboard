using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidiToKeyboard.App.Models;

namespace MidiToKeyboard.App.ViewModels
{
   public class MidiListControlViewModel : BindableBase
    {
        public MidiListControlViewModel()
        {
            DoubleClickCommand = new DelegateCommand(ExecuteDoubleClickCommand);
        }
         ObservableCollection<MidiModel> _midiModels = new ObservableCollection<MidiModel>();
         public ObservableCollection<MidiModel> MidiModels { get=>_midiModels; set=>SetProperty(ref _midiModels,value); }

         private DelegateCommand DoubleClickCommand { get; set; }

         private void ExecuteDoubleClickCommand()
         {
             // 在这里处理双击选中的逻辑
             // ...
         }
    }
}
