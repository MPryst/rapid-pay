using System.ComponentModel.DataAnnotations;

namespace RapidPay.Data.RequestDTOs
{
	public class CreateCard
	{
		[StringLength(15)]
		[Required]
		public string Numbers { get; set; }

		[Required]
		public string CardHolder { get; set; }

		[Required]
		[Range(0, 999)]
		public ushort CVV { get; set; }

		[Required]
		[Range(1, 12)]
		public ushort ExpirationMonth { get; set; }

		[Required]
		[Range(1900, double.MaxValue)]
		public ushort ExpirationYear { get; set; }		
	}
}
