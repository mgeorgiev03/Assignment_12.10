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
            NewMovie.Id = Guid.NewGuid();
            movieService = new MovieService();
            AddNewMovie = new Command(async () => await Add());
        }

        private int rating;
        public int Rating
        {
            get { return rating; }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }
        }

        public Movie NewMovie { get; set; }

        public ICommand AddNewMovie { get; set; }

        public async Task Add()
        {
            NewMovie.Rating = Rating;
            
            await movieService.Create(NewMovie);
            await Shell.Current.Navigation.PushAsync(new MainPage(), true);
        }
    }
}
