using System;
namespace NotesEncrypter.Models
{
	public class Encrypter
	{
		private SymbolTable symbolTable;

		public Encrypter()
        {
			symbolTable = new UnicodeTable();
        }

		public void SetSymbolTable(string name)
        {
			switch (name)
				{
				default: symbolTable = new UnicodeTable(); break;
				}
        }

		public string Encrypt(string str, string k)
        {
			KeyString key = new KeyString(k);
			string res = "";
			int tmp;

			for (int i = 0; i < str.Length; i++)
			{
                tmp = symbolTable.IndexOf(str[i]) + symbolTable.IndexOf(key.GetNextChar());
				if (tmp >= symbolTable.GetSize())
					tmp -= symbolTable.GetSize();
				res += symbolTable.CharAt(tmp);
            }

			return res;
		}

		public string Decrypt(string str, string k)
		{
			KeyString key = new KeyString(k);
			string res = "";
			int tmp;

			for (int i = 0; i < str.Length; i++)
			{
				tmp = symbolTable.IndexOf(str[i]) - symbolTable.IndexOf(key.GetNextChar());
				if (tmp < 0)
					tmp += symbolTable.GetSize();
				res += symbolTable.CharAt(tmp);
			}

			return res;
		}

		private class KeyString
		{
			private string key;
			private int pos;

			public KeyString(string k)
			{
				key = k;
				pos = 0;
			}

			public char GetNextChar()
			{
				if (pos == key.Length)
				{
					pos = 0;
				}
				pos++;
				return key[pos - 1];
			}
		}
	}
}
