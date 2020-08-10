using System;
namespace NotesEncrypter.Models
{
	public class CeasarEncrypter : Encrypter
	{
		private SymbolTable symbolTable;

		public CeasarEncrypter()
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
			int key;
			bool isParsable = Int32.TryParse((string) k, out key);

			if (isParsable)
			{
				string res = "";
				int tmp;

				for (int i = 0; i < str.Length; i++)
				{
					tmp = symbolTable.IndexOf(str[i]) + key;
					if (tmp >= symbolTable.GetSize())
						tmp -= symbolTable.GetSize();
					res += symbolTable.CharAt(tmp);
				}

				return res;
			}
			else
				return str;
		}

		public override string Decrypt(string str, object k)
		{
			int key;
			bool isParsable = Int32.TryParse((string)k, out key);

			if (isParsable)
			{
				string res = "";
				int tmp;

				for (int i = 0; i < str.Length; i++)
				{
					tmp = symbolTable.IndexOf(str[i]) - key;
					if (tmp < 0)
						tmp += symbolTable.GetSize();
					res += symbolTable.CharAt(tmp);
				}

				return res;
			}
			else
				return str;
		}
	}
}
