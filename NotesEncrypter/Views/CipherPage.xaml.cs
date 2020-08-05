using System;
using NotesEncrypter.ViewModels;
using Xamarin.Forms;

namespace NotesEncrypter.Views
{
    public partial class CipherPage : ContentPage
    {
        public CipherPage()
        {
            InitializeComponent();
            BindingContext = new CipherViewModel(Navigation);
            ;
        }
    }
}
