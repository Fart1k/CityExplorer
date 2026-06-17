using CityExplorer.Resources.Strings;
using CityExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityExplorer.Models
{
    public class Category : BaseViewModel
    {
        public string Emoji { get; set; }
        public string ResourceKey { get; set; }
        public string Value { get; set; }

        public string Title => AppResources.ResourceManager.GetString(ResourceKey, AppResources.Culture);

    public void Refresh()
        {
            OnPropertyChanged(nameof(Title));
        }
    }
}
