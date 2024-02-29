using RapidPay.Data.Models;
using RapidPay.Data.RequestDTOs;

namespace RapidPay.Services.Interfaces
{
	public interface ICardsService
	{
		public Task<Card> GetCardAsync(string cardNumbers);
		public Task CreateAsync(CreateCard createCard);
		public Task MakePaymentAsync(string cardNumbers, double amount);		
	}
}
