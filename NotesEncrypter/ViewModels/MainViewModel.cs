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

        public List<EncryptionMethod> EncryptionMethods { get { return encryptionMethods; } }

        public MainViewModel(INavigation navigation)
        {
            encryptionMethods = new List<EncryptionMethod>();

            encryptionMethods.Add(new VigenereMethod());
            encryptionMethods.Add(new CeasarMethod());
        }
    }
}
