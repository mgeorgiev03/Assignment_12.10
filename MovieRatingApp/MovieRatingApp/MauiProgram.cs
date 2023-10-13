using Microsoft.Extensions.Logging;
using MovieRatingApp.DataAccess;
using MovieRatingApp.DataAccess.Interfaces;
using MovieRatingApp.Model.Services;
using MovieRatingApp.Model.Services.IServices;

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

		builder.Services.AddSingleton<IDBConnection, DBConnection>();
		builder.Services.AddSingleton<IMovieService, MovieService>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
