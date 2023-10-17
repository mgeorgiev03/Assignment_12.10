using MovieRatingApp.Model.Services.IServices;
using SQLite;
using System.Collections.ObjectModel;

namespace MovieRatingApp.Model.Services
{
    internal class MovieService : IMovieService
    {
        private SQLiteConnection _connection;
        private readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MovieRatingApp.db3");

        public MovieService()
        {
            _connection = new SQLiteConnection(dbPath);
        }

        public void Create(Movie movie)
        {
            _connection.Insert(movie, typeof(Movie));
        }

        public void Delete(Guid id)
        {
            _connection.Table<Movie>().Delete(m => m.Id == id);
        }

        public Movie Get(Guid id)
        {
            return _connection.Get<Movie>(id);
        }

        public ObservableCollection<Movie> GetAll()
        {
            ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
            List<Movie> moviesInDb = _connection.Table<Movie>().ToList();

            foreach (var item in moviesInDb)
            {
                movies.Add(item);
            }
;           
            return movies;
        }

        public void Update(Movie movie)
        {
            _connection.Update(movie, typeof(Movie));
        }
    }
}
