using MovieRatingApp.Model;
using MovieRatingApp.Model.Services;
using MovieRatingApp.Model.Services.IServices;
using MovieRatingApp.Pages;
using System.Windows.Input;

namespace MovieRatingApp.ViewModels
{
    public class AddViewModel : BindableObject
    {
        private IMovieService movieService;
        public AddViewModel()
        {
            NewMovie = new Movie();
            movieService = new MovieService();
            Navigation = new Command(async () => await Navigate());
            AddNewMovie = new Command(Add);
        }

        public Movie NewMovie { get; set; }

        public ICommand AddNewMovie { get; set; }
        public void Add()
        {
            NewMovie.Id = Guid.NewGuid();
            movieService.Create(NewMovie);
        }

        public ICommand Navigation { get; set; }
        async Task Navigate() => await Shell.Current.Navigation.PushAsync(new MainPage(), true);
    }
}
