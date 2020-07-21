using System;
namespace NotesEncrypter.Models
{
    public class UnicodeTable : SymbolTable
    {
        private const int LENGTH = 0xFFFF;

        public override int GetSize() => LENGTH;

        public override int IndexOf(char chr) => chr;

        public override char CharAt(int ind) => (char)ind;
    }
}