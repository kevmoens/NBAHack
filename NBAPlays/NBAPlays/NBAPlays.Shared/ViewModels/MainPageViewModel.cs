using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace NBAPlays.Shared.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool _IsHamburgerMenuOpen;
        public bool IsHamburgerMenuOpen { get { return _IsHamburgerMenuOpen; } set { Set(ref _IsHamburgerMenuOpen, value); } }
        public ICommand HamburgerCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        private Frame _DisplayContent = new Frame() { HorizontalContentAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch, VerticalContentAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch };
        public Frame DisplayContent { get { return _DisplayContent; } set { Set(ref _DisplayContent, value); } }
        public MainPageViewModel ()
        {
            HamburgerCommand = new RelayCommand(() => { IsHamburgerMenuOpen = !IsHamburgerMenuOpen; });
            HomeCommand = new RelayCommand(() => {
                DisplayContent.Navigate(typeof(Views.Home), null);
                IsHamburgerMenuOpen = false;
            });
            SettingsCommand = new RelayCommand(() => {
                DisplayContent.Navigate(typeof(Views.Settings), null); 
                IsHamburgerMenuOpen = false;
            });
        }
    }
}
