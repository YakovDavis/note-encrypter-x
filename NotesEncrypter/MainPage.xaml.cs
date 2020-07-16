using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotesEncrypter
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly Encrypter encrypter;

        public MainPage()
        {
            InitializeComponent();
            encrypter = new Encrypter();
        }

        void HandleEncrypt(object sender, System.EventArgs e)
        {
            if (messageEntry.Text != null && keyEntry.Text != null)
                messageEntry.Text = encrypter.Encrypt(messageEntry.Text, keyEntry.Text);
        }

        void HandleDecrypt(object sender, System.EventArgs e)
        {
            if (messageEntry.Text != null && keyEntry.Text != null)
                messageEntry.Text = encrypter.Decrypt(messageEntry.Text, keyEntry.Text);
        }

        void OnShareClicked(object sender, System.EventArgs e)
        {

        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}
