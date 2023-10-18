using MovieRatingApp.Model.Services.IServices;
using SQLite;
using System.Collections.ObjectModel;

namespace MovieRatingApp.Model.Services
{
    internal class MovieService //: IMovieService
    {
        private SQLiteAsyncConnection _connection;
        private readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MovieRatingApp.db3");

        public MovieService()
        {
            _connection = new SQLiteAsyncConnection(dbPath);
        }

        public async Task Create(Movie movie)
        {
            await _connection.InsertAsync(movie, typeof(Movie));
        }

        public async Task Delete(Guid id)
        {
            await _connection.Table<Movie>().DeleteAsync(m => m.Id == id);
        }

        public async Task<Movie> Get(Guid id)
        {
            return await _connection.GetAsync<Movie>(id);
        }

        public ObservableCollection<Movie> GetAll()
        {
            SQLiteConnection connection = new SQLiteConnection(dbPath);
            ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
            connection.CreateTable<Movie>();
            List<Movie> moviesInDb = connection.Table<Movie>().ToList();

            foreach (var item in moviesInDb)
            {
                movies.Add(item);
            }
;           
            return movies;
        }

        public async Task Update(Movie movie)
        {
            await _connection.UpdateAsync(movie, typeof(Movie));
        }
    }
}
