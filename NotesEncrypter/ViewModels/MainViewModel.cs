using System;
using System.ComponentModel;
using System.Windows.Input;
using NotesEncrypter.Views;
using NotesEncrypter.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace NotesEncrypter.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        protected readonly Encrypter encrypter;

        protected string _messageText;
        protected string _keyText;

        public ICommand EncryptCommand { get; }
        public ICommand DecryptCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand ShareCommand { get; }

        public INavigation Navigation { get; set; }

        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                OnPropertyChanged("MessageText");
            }
        }

        public string KeyText
        {
            get { return _keyText; }
            set
            {
                _keyText = value;
                OnPropertyChanged("KeyText");
            }
        }

        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;

            encrypter = new Encrypter();
            if (Preferences.ContainsKey("symbol_table"))
                encrypter.SetSymbolTable(Preferences.Get("symbol_table", "unicode"));
            else
                Preferences.Set("symbol_table", "Unicode");

            EncryptCommand = new Command(Encrypt);
            DecryptCommand = new Command(Decrypt);
            SettingsCommand = new Command(OpenSettings);
            ShareCommand = new Command(ShareMessage);
        }

        public void ChangeSymbolTable(string name)
        {
            encrypter.SetSymbolTable(name);
        }

        void Encrypt()
        {
            if (MessageText != null && KeyText != null)
                MessageText = encrypter.Encrypt(MessageText, KeyText);
        }

        void Decrypt()
        {
            if (MessageText != null && KeyText != null)
                MessageText = encrypter.Decrypt(MessageText, KeyText);
        }

        void ShareMessage()
        {
            _ = ShareMessageTask();
        }

        async Task ShareMessageTask()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = MessageText,
                Title = "Share Message"
            });
        }

        void OpenSettings()
        {
            Navigation.PushAsync(new SettingsPage(this));
        }
    }
}
