using MovieRatingApp.Model;
using MovieRatingApp.Model.Services;
using MovieRatingApp.Model.Services.IServices;
using MovieRatingApp.Pages;
using System.Windows.Input;

namespace MovieRatingApp.ViewModels
{
    public class AddViewModel : BindableObject
    {
        private MovieService movieService;
        public AddViewModel()
        {
            NewMovie = new Movie();
            NewMovie.Id = Guid.NewGuid();
            movieService = new MovieService();
            AddNewMovie = new Command(async () => await Add());
        }

        public Movie NewMovie { get; set; }

        public ICommand AddNewMovie { get; set; }
        public async Task Add()
        {
            await movieService.Create(NewMovie);
            await Shell.Current.Navigation.PushAsync(new MainPage(), true);
        }
    }
}
