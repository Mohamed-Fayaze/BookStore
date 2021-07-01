using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using BulkyBook.Utility;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BulkyBook.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IVerification _verificationService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public LoginModel(SignInManager<IdentityUser> signInManager, 
            ILogger<LoginModel> logger,
             IVerification verificationService,
            UserManager<IdentityUser> userManager,
            IEmailSender emailSender,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _verificationService = verificationService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public MobileLogin Mobile { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
           
            [EmailAddress]
            public string Email { get; set; }

            
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class MobileLogin
        {
            
            public string PhoneNumber { get; set; }

            
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public string Code { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostMobile(string returnUrl = null)
        {


            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var temp = Mobile.PhoneNumber.Trim();
                var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.PhoneNumber == temp);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, Mobile.Password, Mobile.RememberMe, lockoutOnFailure: true);
                  
                    if (result.Succeeded)
                    {
                        //var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.PhoneNumber == Mobile.PhoneNumber);

                        int count = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == user.Id).Count();
                        HttpContext.Session.SetInt32(SD.ssShoppingCart, count);

                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }

                    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public async Task<IActionResult> OnPostVerify(string submit, string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("~/");
           
            //var tempno = SMS.FullPhoneNumber;
            if (submit == "Sendotp")
            {
                var matchfound = _unitOfWork.ApplicationUser.GetFirstOrDefault(x => x.PhoneNumber == Mobile.PhoneNumber);

                if (matchfound != null)
                {
                    returnUrl = returnUrl ?? Url.Content("~/");
                    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                    var verification =
                              await _verificationService.StartVerificationAsync(Mobile.PhoneNumber, "sms");
                    if (verification.IsValid)
                    {
                        //SMS.IsValidSMS = true;
                        TempData["Success"] = "OTP has been sent to your Mobile";
                    }
                    else
                    {
                        TempData["Error"] = "Invalid Number..Please Enter Valid Number";
                        return LocalRedirect(Url.Content($"~/Identity/Account/Login"));
                    }
                }
                else
                {
                    TempData["Error"] = "Unregistered Mobile Number";
                    return LocalRedirect(Url.Content($"~/Identity/Account/Login"));
                }
                //if (SMS.IsValidSMS == false)
                //{
                //    ModelState.AddModelError("DuplicateNumber", "Invalid Mobile Number");
                //    return LocalRedirect(Url.Content($"~/Identity/Account/Register"));
                //}


                //return Page();
            }

            else if (submit == "Verifyotp")
            {
                var fullphn = Mobile.PhoneNumber;
                fullphn = fullphn.Replace(" ", "");
                

                returnUrl = returnUrl ?? Url.Content("~/");
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                var verificarion = await _verificationService.CheckVerificationAsync(Mobile.PhoneNumber, Mobile.Code);
                if (verificarion.IsValid)
                {
                    var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.PhoneNumber == fullphn);
                    if (user != null)
                    {
                        await _signInManager.SignInAsync(user, Input.RememberMe, "");
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);

                    }
                    else
                    {
                        TempData["Error"] = "Unregistered Mobile Number";
                        return LocalRedirect(Url.Content($"~/Identity/Account/Login"));
                    }

                }
                else
                {
                    TempData["Error"] = "OTP verification failed..please enter valid OTP";
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {


            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Email == Input.Email);

                    int count = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == user.Id).Count();
                    HttpContext.Session.SetInt32(SD.ssShoppingCart, count);

                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    //ModelState.AddModelError(string.Empty, "Invalid login Credentials.");
                    TempData["Error"] = "Invalid Login Credentials";
                    //return Page();
                }
            }
            
            // If we got this far, something failed, redisplay form
            return Page();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                Input.Email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return Page();
        }
    }
}
