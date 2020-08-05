using System;
using NotesEncrypter.Resx;

namespace NotesEncrypter.Models
{
    public class CeasarMethod : EncryptionMethod
    {
        public string Name { get { return AppResources.CeasarCipherName; } }

        public string Description { get { return AppResources.CeasarCipherDescription; } }

        public string Image { get { return "ceasar.png"; } }

        public override Encrypter GetEncrypter() => new VigenereEncrypter();
    }
}
