using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidPay.Data.Models
{
	[Table("Cards")]
	public class Card
	{		
		[Key]
		public Guid Id { get; set; }
		
		[Required]
		[StringLength(15)]
		public string Numbers { get; set; }

		[DefaultValue(0)]
		public double Balance { get; set; }

		[Required]
		[RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "Incorrect format for card holder.")]
		public string CardHolder { get; set; }

		[Required]
		[Range(0,999)]
		public ushort CVV { get; set; }

		[Required]
		[Range(1,12)]
		public ushort ExpirationMonth { get; set; }

		[Required]
		[Range(1900, double.MaxValue)]
		public ushort ExpirationYear { get; set; }
	}
}
