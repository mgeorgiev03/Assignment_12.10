using MovieRatingApp.Model;
using MovieRatingApp.Model.Services;
using MovieRatingApp.Model.Services.IServices;
using MovieRatingApp.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieRatingApp.ViewModels
{
    public class MovieViewModel : BindableObject
    {
        private readonly IMovieService movieService;
        public MovieViewModel()
        {
            movieService = new MovieService();
            Navigation = new Command(async () => await Navigate());
        }

        private ObservableCollection<Movie> movies;
        public ObservableCollection<Movie> Movies
        {
            get => movies;
            set => movies = value;
        }

        public ICommand Navigation;

        async Task Navigate() => await Shell.Current.Navigation.PushAsync(new AddPage(), true);
    }
}
