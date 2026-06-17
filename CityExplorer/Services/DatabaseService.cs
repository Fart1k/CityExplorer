using CityExplorer.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityExplorer.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection database;

        public DatabaseService()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "CityExplorer.db3");

            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Place>().Wait();
        }

        public async Task<List<Place>> GetFavoritesAsync()
        {
            return await database.Table<Place>()
                .Where(p => p.IsFavorite)
                .ToListAsync();
        }

        public async Task AddFavoriteAsync(Place place)
        {
            place.IsFavorite = true;
            await database.UpdateAsync(place);
        }

        public async Task DeleteFavoriteAsync(Place place)
        {
            place.IsFavorite = false;
            await database.UpdateAsync(place);
        }
    }
}
