using Microsoft.Extensions.Logging;
using MyApp.Pages;
using MyApp.Services;
using MyApp.ViewModels;

namespace MyApp;

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
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<ContactPage>();
		builder.Services.AddSingleton<AboutPage>();


		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<LoginPage>();

        builder.Services.AddSingleton<DetailsViewModel>();
        builder.Services.AddSingleton<DetailsPage>();

        builder.Services.AddSingleton<EmployeeListModel>();
        builder.Services.AddSingleton<EmployeeListPage>();
        builder.Services.AddSingleton<EmployeeListService>();
		 
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
