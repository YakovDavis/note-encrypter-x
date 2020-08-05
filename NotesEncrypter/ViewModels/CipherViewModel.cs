using System;
using System.ComponentModel;
using System.Windows.Input;
using NotesEncrypter.Views;
using NotesEncrypter.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using NotesEncrypter.Resx;

namespace NotesEncrypter.ViewModels
{
    public class CipherViewModel : BaseViewModel
    {
        protected readonly Encrypter encrypter;

        protected string _messageText;
        protected string _keyText;

        protected bool _usePresetKey;
        protected bool _hideKey;

        public ICommand EncryptCommand { get; }
        public ICommand DecryptCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand ShareCommand { get; }

        public INavigation Navigation { get; set; }

        public bool UsePresetKey
        {
            get { return _usePresetKey; }

            protected set
            {
                _usePresetKey = value;
                OnPropertyChanged("UsePresetKey");
            }
        }

        public bool HideKey
        {
            get { return _hideKey; }

            set
            {
                _hideKey = value;
                Preferences.Set("hide_key", value);
                OnPropertyChanged("HideKey");
            }
        }

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

        public CipherViewModel(INavigation navigation)
        {
            Navigation = navigation;

            encrypter = new VigenereEncrypter();
            if (Preferences.ContainsKey("symbol_table"))
                encrypter.SetSymbolTable(Preferences.Get("symbol_table", "Unicode"));
            else
                Preferences.Set("symbol_table", "Unicode");

            if (Preferences.ContainsKey("use_preset_key"))
            {
                if (Preferences.Get("use_preset_key", false))
                {
                    if (Preferences.ContainsKey("preset_key"))
                        SetPresetKey(Preferences.Get("preset_key", ""));
                    else
                        Preferences.Set("preset_key", "");
                }
                else
                    SetPresetKey("");
            }
            else
                Preferences.Set("preset_key", "");

            EncryptCommand = new Command(Encrypt);
            DecryptCommand = new Command(Decrypt);
            SettingsCommand = new Command(OpenSettings);
            ShareCommand = new Command(ShareMessage);

            HideKey = Preferences.Get("hide_key", false);
        }

        public void ChangeSymbolTable(string name)
        {
            encrypter.SetSymbolTable(name);
        }

        public void SetPresetKey(string key)
        {
            if (key.Length > 0)
            {
                KeyText = key;
                UsePresetKey = true;
            }
            else
                UsePresetKey = false;
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
            if (MessageText != null)
                if (MessageText.Length > 0)
                    _ = ShareMessageTask();
        }

        async Task ShareMessageTask()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = MessageText,
                Title = AppResources.ShareMessage
            });
        }

        void OpenSettings()
        {
            Navigation.PushAsync(new SettingsPage(this));
        }
    }
}
