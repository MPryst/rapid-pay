using RapidPay.Data.Models;
using RapidPay.Data.RequestDTOs;

namespace RapidPay.Data.Interfaces
{
	public interface ICardsRepository
	{
		Task CreateCardAsync(CreateCard createCard);
		Task<Card> GetCardAsync(string number);
		Task UpdateBalanceAsync(string cardNumber, double amount);
	}
}
