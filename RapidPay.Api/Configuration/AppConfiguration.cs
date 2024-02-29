using RapidPay.Api.Authorization;

namespace RapidPay.Api.Configuration
{
	public static class AppConfiguration
	{
		public static void Configure(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapPost("/connect/token", (HttpContext context, JwtOptions jwtOptions) => TokenEndpoint.Connect(context, jwtOptions));
			app.MapControllers();
	
		}
	}
}
