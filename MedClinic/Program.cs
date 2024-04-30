using MedClinicBL.LogInService;
using MedClinicBL.Services;
using MedClinicDAL;
using MedClinicDAL.IRepository;
using MedClinicDAL.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MedClinic
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(cookie=>cookie.LoginPath="/Home/LogIn");
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>(ServiceLifetime.Scoped);
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
            builder.Services.AddScoped<ILogIn, LogIn>();
			builder.Services.AddScoped<IRolesRepository, RolesRepository>();
			builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
			builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
			builder.Services.AddScoped<ISlotCreator, SlotCreator>();
			builder.Services.AddScoped<ISlotRepository, SlotRepository>();
            builder.Services.AddScoped<IClinicRepository,ClinicRepository>();
           // builder.Services.AddHostedService<SlotCleanupService>();//don`t understand why need this ????????
			var app = builder.Build();

			app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("def","{controller=Home}/{action=Index}");
            });

            await app.RunAsync();
        }
    }
}