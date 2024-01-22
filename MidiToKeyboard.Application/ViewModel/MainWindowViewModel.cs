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
        private ObservableCollection<SongView> _SongViews = new();
        public ObservableCollection<SongView> SongViews
        {
            get =>_SongViews;
            set
            {
                SetProperty(ref _SongViews, value); 
            }
        }
      
    }
}
