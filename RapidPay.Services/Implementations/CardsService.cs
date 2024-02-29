using RapidPay.Data.Interfaces;
using RapidPay.Data.Models;
using RapidPay.Data.RequestDTOs;
using RapidPay.Services.Interfaces;
using RapidPay.UFE;

namespace RapidPay.Services.Implementations
{
	public class CardsService : ICardsService
	{
		private readonly ICardsRepository _cardsRepository;

		public CardsService(ICardsRepository cardsRepository) => _cardsRepository = cardsRepository;

		public async Task CreateAsync(CreateCard createCard) => await _cardsRepository.CreateCardAsync(createCard);

		public async Task<Card> GetCardAsync(string number) => await _cardsRepository.GetCardAsync(number);

		public async Task MakePaymentAsync(string cardNumber, double amount)
		{
			double paymentFee = amount * UniversalExchange.Fee;

			await _cardsRepository.UpdateBalanceAsync(cardNumber, amount + paymentFee);
		}
	}
}
