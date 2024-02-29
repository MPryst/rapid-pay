namespace RapidPay.UFE
{
	public class UniversalFeesExchangeWorker : BackgroundService
	{
		private readonly Random _random;

		public UniversalFeesExchangeWorker()
		{
			_random = new Random();
			UniversalExchange.Fee = GetNextFeeValue(1d);
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				UniversalExchange.Fee = GetNextFeeValue(UniversalExchange.Fee);				
				await Task.Delay(3600000, stoppingToken);
			}
		}

		private double GetNextFeeValue(double previousValue) => previousValue * (_random.Next(2000) / 1000d);
	}
}
