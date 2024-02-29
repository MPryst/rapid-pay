using Microsoft.EntityFrameworkCore;
using RapidPay.Data.Interfaces;
using RapidPay.Data.Models;
using RapidPay.Data.RequestDTOs;

namespace RapidPay.Data.Implementations
{
	public class CardsRepository : ICardsRepository
	{
		private readonly RapidPayDbContext _rapidPayDbContext;

		public CardsRepository(RapidPayDbContext rapidPayDbContext)
		{
			this._rapidPayDbContext = rapidPayDbContext;
		}

		public async Task CreateCardAsync(CreateCard createCard)
		{
			var newCard = new Card()
			{
				Id = Guid.NewGuid(),
				CardHolder = createCard.CardHolder,
				ExpirationMonth = createCard.ExpirationMonth,
				ExpirationYear = createCard.ExpirationYear,
				CVV = createCard.CVV,
				Numbers = createCard.Numbers,
				Balance = 0
			};
			
			await _rapidPayDbContext.AddAsync<Card>(newCard);
			await _rapidPayDbContext.SaveChangesAsync();
		}

		public async Task<Card> GetCardAsync(string number)
		{
			var result = await _rapidPayDbContext.Set<Card>().Where(x => x.Numbers == number).ToListAsync();
			return result.SingleOrDefault();
		}

		public async Task UpdateBalanceAsync(string cardNumber, double amount)
		{
			var card = await GetCardAsync(cardNumber);
			card.Balance -= amount;
			await _rapidPayDbContext.SaveChangesAsync();
		}
	}
}
