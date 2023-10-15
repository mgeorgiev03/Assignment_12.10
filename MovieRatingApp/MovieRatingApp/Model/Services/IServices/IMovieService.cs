namespace MovieRatingApp.Model.Services.IServices
{
    public interface IMovieService
    {
        Task<Guid> Create(Movie movie);
        Task Update(Movie movie);
        Task Delete(Guid id);
        Task<Movie> Get(Guid id);
        Task<ICollection<Movie>> GetAll();
    }
}
