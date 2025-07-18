﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using DPMOPS.Models;
using DPMOPS.Services.City;
using DPMOPS.Services.District;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;

namespace DPMOPS.Areas.Identity.Pages.Account
{
    public class RegisterEmployeeModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        private readonly IAuthorizationService _authService;

        public RegisterEmployeeModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ICityService cityService,
            IDistrictService districtService,
            IAuthorizationService authService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _cityService = cityService;
            _districtService = districtService;
            _authService = authService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        public IEnumerable<SelectListItem> CityOptions { get; set; }
        public IEnumerable<SelectListItem> DistrictOptions { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "{0} مطلوب")]
            [EmailAddress(ErrorMessage = "يجب عليك ادخال بريد الكتروني صالح")]
            [Display(Name = "البريد الالكتروني")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "{0} مطلوبة")]
            [StringLength(100, ErrorMessage = "{0} يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "كلمة السر")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "تأكيد كلمة السر")]
            [Compare("Password", ErrorMessage = "كلمة السر والتأكيد ليسا متطابقان")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "{0} مطلوب")]
            [DataType(DataType.Text)]
            [Display(Name = "الاسم الاول")]
            [StringLength(25, ErrorMessage = "{0} يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 2)]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "{0} مطلوبة")]
            [DataType(DataType.Text)]
            [Display(Name = "الكنية")]
            [StringLength(25, ErrorMessage = "{0} يجب ان يكون اقصر من {1} حرف و اطول من {2} حرف ", MinimumLength = 2)]
            public string LastName { get; set; }

            [Display(Name = "العنوان")]
            [Required(ErrorMessage = "{0} مطلوب")]
            public Guid DistrictId { get; set; }

            [Required(ErrorMessage = "{0} مطلوب")]
            [RegularExpression(@"^09\d{8}$", ErrorMessage = "رقم المحمول يجب ان يبدأ ب09 و ان يكون مؤلف من عشر خانات")]
            [Display(Name = "رقم المحمول")]
            public string PhoneNumber { get; set; }
        }


        public async Task<IActionResult> OnGetAsync(Guid OrgId, string returnUrl = null)
        {
            AuthorizationResult authResult = await _authService.AuthorizeAsync(User, OrgId, "IsAdminOrOrgAdmin");
            if (!authResult.Succeeded)
            {
                return new ForbidResult();
            }

            CityOptions = await _cityService.GetCityOptionsAsync();
            DistrictOptions = Enumerable.Empty<SelectListItem>();

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return Page();
        }

        public async Task<JsonResult> OnGetDistrictsByCity(Guid cityId)
        {
            var districts = await _districtService.GetDistrictOptionsByCityAsync(cityId);
            return new JsonResult(districts);
        }

        public async Task<IActionResult> OnPostAsync(Guid orgId, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.DistrictId = Input.DistrictId;
                user.DateCreated = DateTime.Now;
                user.OrganizationId = orgId;
                user.PhoneNumber = Input.PhoneNumber;
                user.EmailConfirmed = true;

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var OrgIdClaim = new Claim("OrganizationId", user.OrganizationId.ToString());
                    await _userManager.AddClaimAsync(user, OrgIdClaim);

                    var userId = await _userManager.GetUserIdAsync(user);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("/Organization/Employees/Index", new { id = orgId });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            CityOptions = await _cityService.GetCityOptionsAsync();
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
