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
			app.UseAuthorization();
			app.MapControllers();
		}
	}
}
