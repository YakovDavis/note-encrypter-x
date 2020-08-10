using System;
using NotesEncrypter.ViewModels;
using NotesEncrypter.Models;
using Xamarin.Forms;

namespace NotesEncrypter.Views
{
    public partial class CipherPage : ContentPage
    {
        public CipherPage(EncryptionMethod method)
        {
            InitializeComponent();
            BindingContext = new CipherViewModel(Navigation, method);
            ;
        }
    }
}
