using Microsoft.Extensions.Logging;
using MovieRatingApp.Model.Services;
using MovieRatingApp.Model.Services.IServices;
using MovieRatingApp.Pages;
using MovieRatingApp.ViewModels;

namespace MovieRatingApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IMovieService, MovieService>();

		builder.Services.AddTransient<MovieViewModel>();
		builder.Services.AddTransient<AddViewModel>();

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<AddPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
