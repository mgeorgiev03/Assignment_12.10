using MovieRatingApp.Model.Services.IServices;
using SQLite;

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

        public ICollection<Movie> GetAll()
        {
            return _connection.Table<Movie>().ToList();
        }

        public void Update(Movie movie)
        {
            _connection.Update(movie, typeof(Movie));
        }
    }
}
