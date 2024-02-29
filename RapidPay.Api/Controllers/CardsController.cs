﻿using Microsoft.AspNetCore.Mvc;
using RapidPay.Api.ResponseDTOs;
using RapidPay.Data.RequestDTOs;
using RapidPay.Services.Interfaces;

namespace RapidPay.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardsController : ControllerBase
	{
		private readonly ICardsService _cardService;

		public CardsController(ICardsService cardService) => _cardService = cardService;

		[HttpPost]
		public async Task<IActionResult> CreateCard([FromBody] CreateCard createCard)
		{
			await _cardService.CreateAsync(createCard);
			return StatusCode(StatusCodes.Status201Created, createCard);
		}

		[HttpGet("/{cardNumber}")]
		public async Task<IActionResult> GetBalance([FromRoute] string cardNumber)
		{
			var card = await _cardService.GetCardAsync(cardNumber);
			if (card == null)
				return NotFound("Card not found in the system.");

			var result = new CardBalance()
			{
				Balance = card.Balance,
				Numbers = card.Numbers
			};

			return Ok(result);
		}

		[HttpPut("/{cardNumber}")]
		public async Task<IActionResult> MakePayment([FromRoute] string cardNumber, [FromBody] Payment payment)
		{
			await _cardService.MakePaymentAsync(cardNumber, payment.Amount);
			
			return Ok("Payment successful.");
		}
	}
}