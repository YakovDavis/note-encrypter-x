using System;
using NotesEncrypter.ViewModels;
using Xamarin.Forms;

namespace NotesEncrypter.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(MainViewModel _mainViewModel)
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel(_mainViewModel);
        }
    }
}
