using MAUI_LABS.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;


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

    
        builder.Services.AddHttpClient<IRateService, RateService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates");
        });

        builder.Services.AddSingleton<ConverterPage>();


        return builder.Build();
	}



}
