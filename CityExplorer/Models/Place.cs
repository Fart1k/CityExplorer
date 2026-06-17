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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
    }
}
