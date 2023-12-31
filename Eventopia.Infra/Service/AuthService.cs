﻿using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Eventopia.Infra.Service;

public class AuthService : IAuthService
{
	private readonly IAuthRepository _authRepository;
	private readonly IConfiguration _configuration;

	public AuthService(IAuthRepository authRepository, IConfiguration configuration)
	{
		_authRepository = authRepository;
		_configuration = configuration;
	}

	public bool CheckEmailExists(string email)
	{
		return _authRepository.CheckEmailExists(email);
	}

	public bool CheckUsernameExists(string username)
	{
		return _authRepository.CheckUsernameExists(username);
	}

	public string? Login(LoginDTO loginDTO)
	{
		var result = _authRepository.Login(loginDTO);

		if (result == null)
		{
			return null;
		}
		else
		{
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value));
			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim> {
				new Claim("Username", result.Username),
				new Claim("RoleId", result.RoleId.ToString()),
				new Claim("UserId", result.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Iss, _configuration.GetSection("AppSettings:Issuer").Value),
				new Claim(JwtRegisteredClaimNames.Aud, _configuration.GetSection("AppSettings:Audience").Value)
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
