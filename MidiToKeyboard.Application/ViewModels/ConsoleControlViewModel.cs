using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidiToKeyboard.App.Models;
using MidiToKeyboard.Midi.MidiSong;

namespace MidiToKeyboard.App.ViewModels
{
   public class ConsoleControlViewModel:BindableBase
   {
       private double _ProcessorMinValue = 0;
       public double ProcessorMinValue { get => _ProcessorMinValue; set => SetProperty(ref _ProcessorMinValue, value); }
       private double _ProcessorMaxValue = 0;
       public double ProcessorMaxValue { get => _ProcessorMaxValue; set => SetProperty(ref _ProcessorMaxValue, value); }

       private double _ProcessorCurrentValue = 0;
       public double ProcessorCurrentValue { get => _ProcessorCurrentValue; set => SetProperty(ref _ProcessorCurrentValue, value); }

        private bool _IsPause = false;
        public bool IsPause { get => _IsPause; set => SetProperty(ref _IsPause, value); }

        private bool _IsPlay = true;
        public bool IsPlay
        {
            get=>_IsPlay;
            set { SetProperty(ref _IsPlay, value);
                IsPause = !value;
            }
        }
    }
}
