using Microsoft.EntityFrameworkCore;
using RapidPay.Data;

namespace RapidPay.Api.Configuration
{
	public static class DatabaseConfiguration
	{
		public static void MigrateDatabase(this IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

			var context = serviceScope.ServiceProvider.GetService<RapidPayDbContext>();
			context?.Database.Migrate();
		}
	}
}
