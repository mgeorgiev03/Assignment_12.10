using MovieRatingApp.DataAccess.Interfaces;
using MovieRatingApp.Model;
using SQLite;

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

                //change 
                var result = new CreateTableResult();

                if (!_connection.Table<Movie>().Equals(null))
                    result = await _connection.CreateTableAsync<Movie>();


                return _connection;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
