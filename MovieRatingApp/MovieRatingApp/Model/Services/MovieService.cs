using MovieRatingApp.DataAccess.Interfaces;
using MovieRatingApp.Model.Services.IServices;
using SQLite;

namespace MovieRatingApp.Model.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IDBConnection _db;
        private SQLiteAsyncConnection _connection;

        public MovieService(IDBConnection dB)
        {
            _db = dB;
            //check later
            //_db.Connect();
        }

        public async Task<Guid> Create(Movie movie)
        {
            try
            {
                _connection = await _db.Connect();

                //change
                var result = await _connection.InsertAsync(movie, typeof(Movie));

                //look up toast

                //if (result > 0)
                //{
                //    await Toast.MakeText($"Employee '{movie.Title}' successfully saved!").Show();
                //    return true;
                //}
                //else
                //{
                //    await Toast.Make("Sorry, we couldn't save your employee. Please try again.").Show();
                //    return false;
                //}

                return movie.Id;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                await _db.Connect();
                await _connection.Table<Movie>().DeleteAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Movie> Get(Guid id)
        {
            try
            {
                await _db.Connect();
                return await _connection.GetAsync<Movie>(id); 
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ICollection<Movie>> GetAll()
        {
            try
            {
                await _db.Connect();
                return await _connection.Table<Movie>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task Update(Movie movie)
        {
            try
            {
                await _db.Connect();
                await _connection.UpdateAsync(movie, typeof(Movie));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
