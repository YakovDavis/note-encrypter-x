using System;
using NotesEncrypter.ViewModels;
using Xamarin.Forms;

namespace NotesEncrypter.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(CipherViewModel _cipherViewModel)
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel(_cipherViewModel);
        }
    }
}
