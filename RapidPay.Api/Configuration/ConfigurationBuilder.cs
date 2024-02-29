using System.Globalization;

namespace RapidPay.Api.Configuration
{
	public static class ConfigurationBuilder
	{
		public static IConfigurationBuilder GetConfiguration(this ConfigurationManager configurationManager, string environment) {
			return configurationManager.SetBasePath(Directory.GetCurrentDirectory())
				   .AddJsonFile(GetConfigurationFilePath(), optional: false, reloadOnChange: true)
				   .AddJsonFile(GetConfigurationFilePath(environment), optional: true, reloadOnChange: true);
		}

		private static string GetConfigurationFilePath(string environmentName = null)
		{
			return String.Format(CultureInfo.InvariantCulture, "appsettings{0}.json", environmentName);
		}
	}
}
