using System;
using NotesEncrypter.ViewModels;
using Xamarin.Forms;

namespace NotesEncrypter.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(Navigation);
;        }
    }
}
