﻿using System;
using NotesEncrypter.Resx;

namespace NotesEncrypter.Models
{
    public class VigenereMethod : EncryptionMethod
    {
        public string Name { get { return AppResources.VigeneresCipherName; } }

        public string Description { get { return AppResources.VigeneresCipherDescription; } }

        public string Image { get { return "vigenere.png"; } }

        public override Encrypter GetEncrypter() => new VigenereEncrypter();
    }
}