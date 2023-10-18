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
        private readonly MovieService movieService;
        public MovieViewModel()
        {
            movieService = new MovieService();
            Navigation = new Command(async () => await Navigate());
            LoadMovies();
        }

        private ObservableCollection<Movie> movies;
        public ObservableCollection<Movie> Movies
        {
            get => movies;
            set => movies = value;
        }

        void LoadMovies()
        {
            Movies = movieService.GetAll();
        }
        public ICommand Navigation { get; set; }

        async Task Navigate() => await Shell.Current.Navigation.PushAsync(new AddPage());
    }
}
