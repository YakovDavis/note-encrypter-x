using System;
using System.ComponentModel;
using System.Windows.Input;
using NotesEncrypter.Views;
using NotesEncrypter.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using NotesEncrypter.Resx;
using System.Collections.Generic;

namespace NotesEncrypter.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        protected List<EncryptionMethod> encryptionMethods;

        protected INavigation Navigation;

        public ICommand SelectCipherCommand { get; }

        public List<EncryptionMethod> EncryptionMethods { get { return encryptionMethods; } }

        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;

            encryptionMethods = new List<EncryptionMethod>();

            encryptionMethods.Add(new VigenereMethod());
            encryptionMethods.Add(new CeasarMethod());

            SelectCipherCommand = new Command<EncryptionMethod>((param) => SelectCipher(param));
        }

        void SelectCipher(EncryptionMethod method)
        {
            Navigation.PushAsync(new CipherPage(method));
        }
    }
}
