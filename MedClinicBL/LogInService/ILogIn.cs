using MedClinicDAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicBL.LogInService
{
	public interface ILogIn
	{
		Task LogInAsync(string userEmail, HttpContext context,string role);
	}

}
