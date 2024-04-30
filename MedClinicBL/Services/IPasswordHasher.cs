using MedClinicDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicBL.Services
{
	public interface IPasswordHasher
	{
		string HashPassword(string password);
		public bool IsCorrectPassword(User user, string password);

	}
}
