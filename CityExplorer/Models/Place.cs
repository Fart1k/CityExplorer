using CityExplorer.Resources.Strings;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityExplorer.Models
{
    public class Place
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }

        public string NameKey { get; set; }
        public string DescriptionKey { get; set; }

        public string Name => AppResources.ResourceManager.GetString(NameKey, AppResources.Culture);
        public string Description => AppResources.ResourceManager.GetString(DescriptionKey, AppResources.Culture);
    }
}
