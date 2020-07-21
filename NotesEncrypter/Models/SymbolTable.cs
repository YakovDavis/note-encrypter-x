using System;
namespace NotesEncrypter.Models
{
    public abstract class SymbolTable
    {
        public abstract string DisplayName { get; }

        public abstract int GetSize();

        public abstract int IndexOf(char chr);

        public abstract char CharAt(int ind);
    }
}
