using System;
namespace NotesEncrypter.Models
{
	public class VigenereEncrypter : Encrypter
	{
		private SymbolTable symbolTable;

		public VigenereEncrypter()
        {
			symbolTable = new UnicodeTable();
        }

		public override void SetSymbolTable(string name)
        {
			switch (name)
			{
				case "Basic": symbolTable = new BasicTable(); break;
				case "Extended": symbolTable = new ExtendedTable(); break;
				default: symbolTable = new UnicodeTable(); break;
			}
        }

		public override string Encrypt(string str, object k)
        {
			KeyString key = new KeyString((string) k);
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

		public override string Decrypt(string str, object k)
		{
			KeyString key = new KeyString((string) k);
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
