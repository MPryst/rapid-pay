using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RapidPay.Api.Configuration
{
	public static class SecurityConfiguration
	{
		public static void AddSecurity(this IServiceCollection services, Authorization.JwtOptions jwtOptions)
		{
			services.AddSingleton(jwtOptions);
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(opts =>
					{
						byte[] signingKeyBytes = Encoding.UTF8.GetBytes(jwtOptions?.SigningKey);

						opts.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuer = true,
							ValidateAudience = true,
							ValidateLifetime = true,
							ValidateIssuerSigningKey = true,
							ValidIssuer = jwtOptions.Issuer,
							ValidAudience = jwtOptions.Audience,
							IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
						};
					});

			services.AddAuthorization();
		}
	}
}
