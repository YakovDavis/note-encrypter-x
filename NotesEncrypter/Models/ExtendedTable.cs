using System;
namespace NotesEncrypter.Models
{
    public class ExtendedTable : SymbolTable
    {
        private readonly string TABLE;
        private readonly int LENGTH;

        public ExtendedTable()
        {
            for (char c = 'A'; c <= 'Z'; c++) TABLE += c;
            for (char c = 'a'; c <= 'z'; c++) TABLE += c;
            TABLE += "0123456789~!?@#$%^&*()_-=+[]{}/\\'`\";: ";
            TABLE += "\u2116\u0401\u0451";
            for (char c = '\u0410'; c <= '\u044F'; c++) TABLE += c;
            TABLE +=
            "\u00bd\u2153\u00bc\u215b\u2154\u00be\u215c\u00a1" +
            "\u00b9\u00b2\u00b3\u2074\u00a2\u2030\u215d\u00bf" +
            "\u215e\u2022\u2605\u221e\u207f\u2248\u2260\u00b1" +
            "\u00d7\u2264\u2265\u00f1\u00a9\u00a7\u00b0\u00d8" +
            "\u00a3\u04e8\u221a\u20b4\u00a5\u2122\u00ae\u20ac";

            LENGTH = TABLE.Length;
        }

        public override int GetSize() => LENGTH;

        public override int IndexOf(char chr) => TABLE.IndexOf(chr);

        public override char CharAt(int ind) => TABLE[ind];
    }
}