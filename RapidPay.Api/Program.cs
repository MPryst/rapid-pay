using RapidPay.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
var environment = "." + builder.Environment.EnvironmentName.ToLower();
var configuration = builder.Configuration.GetConfiguration(environment).Build();

builder.Services.ConfigureServices(configuration);

var app = builder.Build();
app.MigrateDatabase();
app.Configure();
app.Run();