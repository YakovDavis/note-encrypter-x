using System;
using System.Collections.Generic;
using NotesEncrypter.Models;
using Xamarin.Essentials;

namespace NotesEncrypter.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        protected readonly List<string> symbolTableNames;

        protected MainViewModel mainViewModel;

        protected string _selectedTable;

        public string SelectedTable
        {
            get { return _selectedTable; }

            set
            {
                _selectedTable = value;
                mainViewModel.ChangeSymbolTable(value);
                Preferences.Set("symbol_table", value);
                OnPropertyChanged("SelectedTable");
            }
        }

        public List<string> SymbolTableNames { get { return symbolTableNames; } }

        public SettingsViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;

            symbolTableNames = new List<string>
            {
                "Unicode",
                "Basic",
                "Extended"
            };

            _selectedTable = Preferences.Get("symbol_table", "Unicode");
        }
    }
}
