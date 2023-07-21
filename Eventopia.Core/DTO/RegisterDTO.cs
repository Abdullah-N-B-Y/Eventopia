using Eventopia.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.DTO
{
	public class RegisterDTO
	{
		public string? Username { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }
		public string VerificationCode { get; set; } = string.Empty;
		public string UserStatus { get; set; } = "unverified";
		public decimal RoleId { get; set; } = 2;

		public RegisterDTO(string? username, string? password, string? email)
		{
			Username = username;
			Password = password;
			Email = email;
		}
	}
}
