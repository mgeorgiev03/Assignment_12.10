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
            movieService = new MovieService();
            Navigation = new Command(async () => await Navigate());
        }

        public Movie NewMovie { get; set; }

        public void Add()
        {
            NewMovie.Id = Guid.NewGuid();
            movieService.Create(NewMovie);
        }


        public ICommand Navigation;
        async Task Navigate() => await Shell.Current.Navigation.PushAsync(new MainPage(), true);
    }
}
