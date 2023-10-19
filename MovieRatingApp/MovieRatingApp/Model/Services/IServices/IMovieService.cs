using System.Collections.ObjectModel;

namespace MovieRatingApp.Model.Services.IServices
{
    public interface IMovieService
    {
        Task Create(Movie movie);
        Task Update(Movie movie);
        Task Delete(Guid id);
        Task<Movie> Get(Guid id);
        ObservableCollection<Movie> GetAll();
    }
}
