using CloudKit;
using MovieRatingApp.DataAccess.Interfaces;
using MovieRatingApp.Model.Services.IServices;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRatingApp.Model.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IDBConnection _db;
        private SQLiteAsyncConnection _connection;

        public MovieService(IDBConnection dB)
        {
            _db = dB;
        }

        public async Task GetDatabase()
        {
            _connection = await _db.Connect();
        }

        public Task<Guid> Create(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Movie>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
