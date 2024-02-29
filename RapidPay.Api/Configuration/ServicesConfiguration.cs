using Microsoft.EntityFrameworkCore;
using RapidPay.Data;
using RapidPay.Data.Implementations;
using RapidPay.Data.Interfaces;
using RapidPay.Services.Implementations;
using RapidPay.Services.Interfaces;
using RapidPay.UFE;

namespace RapidPay.Api.Configuration
{
	public static class ServicesConfiguration
	{
		public static void ConfigureServices(this IServiceCollection services, IConfigurationRoot configuration)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddDbContext<RapidPayDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("RapidPay")));
			services.AddHostedService<UniversalFeesExchangeWorker>();			

			// Repositories
			services.AddScoped<ICardsRepository, CardsRepository>();

			// Services
			services.AddScoped<ICardsService, CardsService>();
		}
	}
}
