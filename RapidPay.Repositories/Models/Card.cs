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
	}
}
