using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.City;
using DPMOPS.Services.District;
using Microsoft.EntityFrameworkCore;
using DPMOPS.Services.User;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.UserClaim;
using DPMOPS.Services.Organization;
using DPMOPS.Authorization.Requirements;
using DPMOPS.Authorization.Handlers;
using Microsoft.AspNetCore.Authorization;
using DPMOPS.Services.Photo;
using Microsoft.AspNetCore.Identity;
using DPMOPS.Services.Notification;
using DPMOPS.Services.Account;
using DPMOPS.Services.Appointment;
using DPMOPS.Services.Follow;

namespace DPMOPS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy =>
                    policy.Requirements.Add(new AdminRequirement()));

                options.AddPolicy("IsOrgAdmin", policy =>
                    policy.Requirements.Add(new OrgAdminRequirement()));

                options.AddPolicy("IsEmployee", policy =>
                    policy.Requirements.Add(new EmployeeRequirement()));

                options.AddPolicy("SameOrg", policy =>
                policy.AddRequirements(new SameOrgRequirement()));

                options.AddPolicy("IsAdminOrOrgAdmin", policy =>
                policy.AddRequirements(new AdminOrOrgAdminInOrgRequirement()));

                options.AddPolicy("IsCitizen", policy =>
                policy.AddRequirements(new CitizenRequirement()));

                options.AddPolicy("OrgAdminOrYoursPub", policy =>
                policy.AddRequirements(new OrgAdminOrYoursRequirement()));
            });

            builder.Services.AddScoped<IAuthorizationHandler, AdminHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, OrgAdminHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, EmployeeHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, SameOrgHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, AdminOrOrgAdminInOrgHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, CitizenHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, OrgAdminOrYoursHandler>();

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
            builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();
            builder.Services.AddScoped<IUserClaimService, UserClaimService>();
            builder.Services.AddScoped<IOrganizationService, OrganizationService>();
            builder.Services.AddScoped<IPhotoUploadService, PhotoUploadService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IFollowService, FollowService>();

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
