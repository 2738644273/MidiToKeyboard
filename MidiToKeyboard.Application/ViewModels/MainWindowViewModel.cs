using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MidiToKeyboard.App.Views.Controls;

namespace MidiToKeyboard.App.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //注册regionManager控件
        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        { 
          _regionManager = regionManager;
          //ContentRegion是窗口已声明的Region,使用字符串进行弱绑定
          regionManager.RegisterViewWithRegion("LeftRegion",typeof(MidiListControl));
          regionManager.RegisterViewWithRegion("MainRegion", typeof(OperatingStationControl));
          regionManager.RegisterViewWithRegion("BottomRegion", typeof(ConsoleControl));
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title => "六指琴魔";

        public Control _Control = null;

        public Control Control
        {
            get => _Control;
            set=> SetProperty(ref _Control,value);
        }

    }
}
