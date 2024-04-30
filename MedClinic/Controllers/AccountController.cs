using MedClinic.Models;
using MedClinicBL.LogInService;
using MedClinicBL.Services;
using MedClinicDAL.IRepository;
using MedClinicDAL.Models;
using MedClinicDAL.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MedClinic.Controllers
{
	public class AccountController : Controller
	{
		IUserRepository userRepository;
		IPasswordHasher passwordHasher;
		public AccountController(IUserRepository userRepository, IPasswordHasher passwordHasher)
		{
			this.userRepository = userRepository;
			this.passwordHasher = passwordHasher;

		}
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(UserSignUpBindingModel model, [FromServices] IRolesRepository roles)
		{
			if (ModelState.IsValid)
			{
				bool userAlredyExist = userRepository.GetAll().Result.Any(u => u.Email == model.Email || u.PhoneNumber == model.PhoneNumber);
				User newUser;
				if (!userAlredyExist)
				{
					Roles role = await roles.GetByRole("User");
					newUser = new User()
					{
						ID = Guid.NewGuid(),
						Name = model.Name,
						SurName = model.SurName,
						BirthDay = model.Birthday,
						Email = model.Email,
						PhoneNumber = model.PhoneNumber,
						Password = passwordHasher.HashPassword(model.Password),
						RoleId = role.ID
					};
				}
				else
				{
					ModelState.AddModelError(nameof(model.Email), "Email or phone is already in use");
					return View(model);
				}

				userRepository.Add(newUser);
				return RedirectToAction("LogIn");
			}
			return View(model);
		}

		public IActionResult LogIn()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> LogIn(UserLoginBindingModel model, [FromServices] ILogIn logIn)
		{
			if (ModelState.IsValid)
			{
				bool rightEmail = userRepository.GetAll().Result.Any(user => user.Email == model.Email);
				if (rightEmail)
				{
					MedClinicDAL.Models.User user = userRepository.GetAll().Result.FirstOrDefault(em => em.Email == model.Email);
					bool corectpassword = passwordHasher.IsCorrectPassword(user, model.Password);
					if (corectpassword)
					{
						string userRole = userRepository.GetUserIncudeRole(user.RoleId).Result.Role.Role;
						await logIn.LogInAsync(model.Email, HttpContext,userRole);
						return RedirectToAction("Generic","Home");//todo
					}
				}
				ModelState.AddModelError(nameof(model.Email), "Wrong password or email");
				return View(model);
			}
			return View(model);
		}
		public async Task<IActionResult> SignOut()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index","Home");

		}
	}
}
