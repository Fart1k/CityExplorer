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
            return await database.Table<Place>().ToListAsync();
        }

        public async Task AddFavoriteAsync(Place place)
        {
            await database.InsertAsync(place);
        }

        public async Task DeleteFavoriteAsync(Place place)
        {
            await database.DeleteAsync(place);
        }
    }
}
