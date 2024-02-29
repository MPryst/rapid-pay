using Microsoft.EntityFrameworkCore;
using RapidPay.Data.Models;

namespace RapidPay.Data
{
	public class RapidPayDbContext : DbContext
	{
		public RapidPayDbContext(DbContextOptions<RapidPayDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder model)
		{
			model.HasDefaultSchema("RapidPay");
			model.Entity<Card>()
				.HasIndex(e => e.Numbers)
				.IsUnique();
			
			model.Entity<Card>()
				.HasData(
				new Card()
				{
					Id = Guid.NewGuid(),
					Numbers = "123456789012345",
					CardHolder = "Maxi",
					CVV = 123,
					ExpirationMonth = 1,
					ExpirationYear = 2027,
					Balance = 10000
				}
				);
		}

	}
}