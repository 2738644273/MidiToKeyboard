﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MidiToKeyboard.App.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace MidiToKeyboard.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(MainWindowViewModel mainWindow)
        {
            InitializeComponent();
            //监听 主题跟随系统
            Wpf.Ui.Appearance.SystemThemeWatcher.Watch(this);
        }
    }
}