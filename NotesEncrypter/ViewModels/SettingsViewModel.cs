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

        protected bool _usePresetKey;

        protected string _presetKey;

        public bool UsePresetKey
        {
            get { return _usePresetKey; }

            set
            {
                _usePresetKey = value;
                if ((!value) || (PresetKey == null))
                    mainViewModel.SetPresetKey("");
                else
                    mainViewModel.SetPresetKey(PresetKey);
                Preferences.Set("use_preset_key", value);
                OnPropertyChanged("UsePresetKey");
            }
        }

        public string PresetKey
        {
            get { return _presetKey; }

            set
            {
                _presetKey = value;
                if ((!UsePresetKey) || (value == null))
                    mainViewModel.SetPresetKey("");
                else
                    mainViewModel.SetPresetKey(value);
                Preferences.Set("preset_key", value);
                OnPropertyChanged("PresetKey");
            }
        }

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

            SelectedTable = Preferences.Get("symbol_table", "Unicode");
            UsePresetKey = Preferences.Get("use_preset_key", false);
            PresetKey = Preferences.Get("preset_key", "");
        }
    }
}
