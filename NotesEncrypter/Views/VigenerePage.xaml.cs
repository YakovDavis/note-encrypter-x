using System;
using NotesEncrypter.ViewModels;
using Xamarin.Forms;

namespace NotesEncrypter.Views
{
    public partial class VigenerePage : ContentPage
    {
        public VigenerePage()
        {
            InitializeComponent();
            BindingContext = new VigenereViewModel(Navigation);
            ;
        }
    }
}
