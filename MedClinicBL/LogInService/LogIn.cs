using MedClinicDAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MedClinicBL.LogInService
{
	public class LogIn : ILogIn
	{
		public async Task LogInAsync(string userEmail, HttpContext context, string role)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name,userEmail),
				new Claim(ClaimTypes.Role,role)
			};
			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
			var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			await context.SignInAsync(claimsPrincipal);
		}
	}
}
