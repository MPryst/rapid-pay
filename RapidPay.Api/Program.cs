using RapidPay.Api.Authorization;
using RapidPay.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
var environment = "." + builder.Environment.EnvironmentName.ToLower();
var configuration = builder.Configuration.GetConfiguration(environment).Build();
var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();

builder.Services.AddSecurity(jwtOptions);
builder.Services.ConfigureServices(configuration);

var app = builder.Build();
app.MigrateDatabase();
app.Configure();
app.Run();