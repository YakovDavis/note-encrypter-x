﻿using System;
namespace NotesEncrypter.Models
{
    public abstract class EncryptionMethod
    {
        public abstract Encrypter GetEncrypter();
    }
}