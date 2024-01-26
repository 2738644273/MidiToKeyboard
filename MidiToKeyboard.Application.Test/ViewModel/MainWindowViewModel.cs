using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidiToKeyboard.Application.Entity;

namespace MidiToKeyboard.Application.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public string Title => "六指琴魔";
        private ObservableCollection<SongView> _SongList = new();
        public ObservableCollection<SongView> SongList
        {
            get => _SongList;
            set
            {
                SetProperty(ref _SongList, value); 
            }
        }
      
    }
}
