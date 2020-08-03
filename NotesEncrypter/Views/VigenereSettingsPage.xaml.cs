using System;
using NotesEncrypter.ViewModels;
using Xamarin.Forms;

namespace NotesEncrypter.Views
{
    public partial class VigenereSettingsPage : ContentPage
    {
        public VigenereSettingsPage(VigenereViewModel _vigenereViewModel)
        {
            InitializeComponent();
            BindingContext = new VigenereSettingsViewModel(_vigenereViewModel);
        }
    }
}
