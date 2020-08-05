using System;
namespace NotesEncrypter.Models
{
    public abstract class Encrypter
    {
        public abstract void SetSymbolTable(string name);

        public abstract string Encrypt(string str, object k);

        public abstract string Decrypt(string str, object k);
    }
}
