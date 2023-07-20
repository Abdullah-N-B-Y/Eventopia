using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Infra.Service
{
	public class JWTService : IJWTService
	{
		private readonly IJWTRepository _jWTRepository;

		public JWTService(IJWTRepository jWTRepository)
		{
			_jWTRepository = jWTRepository;
		}

		public string? Login(string username, string password)
		{
			var result = _jWTRepository.Login(username, password);

			if (result == null)
			{
				return null;
			}
			else
			{
				// Generate a 256-bit (32 bytes) secure secret key
				var secretKeyBytes = new byte[32];
				using (var rng = new RNGCryptoServiceProvider())
				{
					rng.GetBytes(secretKeyBytes);
				}

				var secretKey = new SymmetricSecurityKey(secretKeyBytes);
				var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
				var claims = new List<Claim> {
					new Claim(ClaimTypes.Name, result.Username),
					new Claim(ClaimTypes.Role, result.Roleid.ToString())
				};

				var tokeOptions = new JwtSecurityToken (
					claims: claims,
					expires: DateTime.Now.AddHours(24), 
					signingCredentials: signinCredentials
				);

				var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
				return tokenString;
			}
		}


	}
}
