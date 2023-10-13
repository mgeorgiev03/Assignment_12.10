using MovieRatingApp.DataAccess.Interfaces;
using MovieRatingApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRatingApp.DataAccess
{
    public class DBConnection : IDBConnection
    {
        private SQLiteAsyncConnection _connection;

        public async Task<SQLiteAsyncConnection> Connect()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MovieRatingApp.db3");
                _connection = new SQLiteAsyncConnection(dbPath);

                var result = await _connection.CreateTableAsync<Movie>();
                return _connection;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
