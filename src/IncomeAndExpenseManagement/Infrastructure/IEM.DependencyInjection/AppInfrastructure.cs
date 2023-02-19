using IEM.Business.DataServices;
using IEM.Business.Interfaces;
using IEM.Data;
using IEM.Data.Interfaces;
using IEM.DependencyInjection.OptionModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IEM.DependencyInjection
{
    public static class AppInfrastructure
    {
        public static void AppDISetup(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure Entity Framework.
            services.AddDbContext<IEM_DbContext>(
                options => options.
                UseSqlServer(configuration.GetConnectionString("DbConnection")));

            // Repository Configuration
            services.AddScoped(typeof(IRepository<>), typeof(IEM.Data.Respository<>));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieOptions =>
                {
                    CookieOptions.LoginPath = "/Authentication/Login";
                    CookieOptions.Cookie = new CookieBuilder
                    {
                        Name = "Income&ExpenditureManagementCookie"
                    };
                });

            // Dependency Injection
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IExpenditureService, ExpenditureService>();

            // Automapper configuration
            services.AddAutoMapper(typeof(BusinessEntityMapping));

            // Setting up all the Option Models
            services.Configure<AccountOption>((option) =>
            {
                // Configure Admin Account for Login into the System
                configuration.GetSection("Account").Bind(option);
            });
        }
    }
}