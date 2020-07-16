using System;
namespace NotesEncrypter
{
    public class BasicTable : SymbolTable
    {
        private readonly string TABLE;
        private readonly int LENGTH;

        public BasicTable()
        {
            for (char c = 'A'; c <= 'Z'; c++) TABLE += c;
            for (char c = 'a'; c <= 'z'; c++) TABLE += c;
            TABLE += "0123456789~!?@#$%^&*()_-=+[]{}/\\'`\";:";
            TABLE += "\u2116\u0401\u0451";
            for (char c = '\u0410'; c <= '\u044F'; c++) TABLE += c;

            LENGTH = TABLE.Length;
        }

        public override int GetSize() => LENGTH;

        public override int IndexOf(char chr) => TABLE.IndexOf(chr);

        public override char CharAt(int ind) => TABLE[ind];
    }
}