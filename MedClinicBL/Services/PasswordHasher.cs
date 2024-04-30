using MedClinicDAL.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicBL.Services
{
	public  class PasswordHasher : IPasswordHasher
	{
		private const string Salt = "fKk+GkLvQBjAhe2VBDBnwg==";

		public string HashPassword(string password)
		{
			return Convert.ToBase64String(KeyDerivation.Pbkdf2(
			   password: password,
			   salt: Convert.FromBase64String(Salt),
			   prf: KeyDerivationPrf.HMACSHA256,
			   iterationCount: 100000,
			   numBytesRequested: 32));
		}

		public bool IsCorrectPassword(User user,string password)
		{
			var passwordHash = HashPassword(password);
			if (passwordHash == user.Password)
				return true;
			return false;
		}
	}
}
