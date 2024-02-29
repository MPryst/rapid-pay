namespace RapidPay.Api.ResponseDTOs
{
	public class CardBalance
	{
		public string Numbers { get; set; }
		public double Balance { get; set; }
		public DateTime Time { get => DateTime.UtcNow; }
	}
}
