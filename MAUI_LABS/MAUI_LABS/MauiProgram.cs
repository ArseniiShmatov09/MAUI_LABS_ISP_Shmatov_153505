using MAUI_LABS.Services;
using Microsoft.Extensions.DependencyInjection;


namespace MAUI_LABS;

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
        builder.Services.AddSingleton<IDbService, SQLiteService>();
        builder.Services.AddSingleton<DataBase>();

        return builder.Build();
	}



}
