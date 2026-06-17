using CityExplorer.Resources.Strings;
using CityExplorer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CityExplorer.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand SetEnglishCommand { get; }
        public ICommand SetEstonianCommand { get; }
        public ICommand SetRussianCommand { get; }

        public string LanguageText => AppResources.Language;

    public SettingsViewModel()
        {
            SetEnglishCommand = new Command(() => LocalizationService.SetLanguage("en"));
            SetEstonianCommand = new Command(() => LocalizationService.SetLanguage("et"));
            SetRussianCommand = new Command(() => LocalizationService.SetLanguage("ru"));
        }
    }
}
