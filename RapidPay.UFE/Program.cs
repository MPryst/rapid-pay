using RapidPay.UFE;

IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices(services =>
	{
		services.AddHostedService<UniversalFeesExchangeWorker>();
	})
	.Build();

await host.RunAsync();
