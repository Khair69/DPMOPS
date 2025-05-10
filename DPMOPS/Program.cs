using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.City;
using DPMOPS.Services.District;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DPMOPS.Services.User;
using DPMOPS.Services.ServiceType;
using DPMOPS.Services.Citizen;
using DPMOPS.Services.ServiceProvider;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.UserClaim;
using DPMOPS.Strategies.Factories;
using DPMOPS.Services.Employee;

namespace DPMOPS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization(options => {
                options.AddPolicy(
                    "IsAdmin",
                    policyBuilder => policyBuilder.RequireClaim("IsAdmin"));

                options.AddPolicy(
                    "IsCitizen",
                    policyBuilder => policyBuilder.RequireClaim("IsCitizen"));

                options.AddPolicy(
                    "IsProvider",
                    policyBuilder => policyBuilder.RequireClaim("IsProvider"));
            });

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => { 
                options.SignIn.RequireConfirmedAccount = true; 
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IDistrictService, DistrictService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IServiceTypeService, ServiceTypeService>();
            builder.Services.AddScoped<ICitizenService, CitizenService>();
            builder.Services.AddScoped<IServiceProviderService, ServiceProviderService>();
            builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IUserClaimService, UserClaimService>();
            builder.Services.AddScoped<IHomePageStrategyFactory, HomePageStrategyFactory>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
