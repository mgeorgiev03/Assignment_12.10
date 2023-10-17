using System.Collections.ObjectModel;

namespace MovieRatingApp.Model.Services.IServices
{
    public interface IMovieService
    {
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(Guid id);
        Movie Get(Guid id);
        ObservableCollection<Movie> GetAll();
    }
}
