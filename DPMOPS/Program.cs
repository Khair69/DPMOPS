using DPMOPS.Authorization.Handlers;
using DPMOPS.Authorization.Requirements;
using DPMOPS.Data;
using DPMOPS.Models;
using DPMOPS.Services.Account;
using DPMOPS.Services.Appointment;
using DPMOPS.Services.City;
using DPMOPS.Services.Comment;
using DPMOPS.Services.District;
using DPMOPS.Services.Follow;
using DPMOPS.Services.Notification;
using DPMOPS.Services.Organization;
using DPMOPS.Services.Photo;
using DPMOPS.Services.ServiceRequest;
using DPMOPS.Services.User;
using DPMOPS.Services.UserClaim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace DPMOPS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new CultureInfo("ar"), new CultureInfo("en") };
                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

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

            // Identity
            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

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
            builder.Services.AddScoped<ICommentService, CommentService>();

            var app = builder.Build();

            var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error/500");

                // Handle status codes like 404, 403, etc.
                app.UseStatusCodePagesWithReExecute("/Error/{0}");

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
