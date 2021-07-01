using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BulkyBook.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IVerification _verificationService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private TwilioSettings _twilioOptions { get; set; }
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IVerification verificationService,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment hostEnvironment,
            IOptions<TwilioSettings> twilionOptions)
        {
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork; ;
            _twilioOptions = twilionOptions.Value;
            _verificationService = verificationService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        [BindProperty]
        public SMSModel SMS { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            //public string StreetAddress { get; set; }
            //public string City { get; set; }
            //public string State { get; set; }
            //public string PostalCode { get; set; }
            //[Required]
            //[DataType(DataType.Currency), RegularExpression(@"^\(?([0-9]{3})\)?([0-9]{3})[-.]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            //[StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
            //[Display(Name = "Phone Number")]
            //public string PhoneNumber { get; set; }
            //[Required]
            //[RegularExpression("\\+\\d+", ErrorMessage = "Write the phone number in the international format without spaces.")]
            //public string FullPhoneNumber { get; set; }
            public int? CompanyId { get; set; }
            public string Role { get; set; }

            //[Required]
            //[Display(Name = "Channel")]
            //public string Channel { get; set; }

            public IEnumerable<SelectListItem> CompanyList { get; set; }
            public IEnumerable<SelectListItem> RoleList { get; set; }
            //[Required]
            //[Display(Name = "Verification Code")]
            //public string Code { get; set; }

        }

        public class SMSModel
        {

            [Required]
            //[DataType(DataType.Currency), RegularExpression(@"^\(?([0-9]{3})\)?([0-9]{3})[-.]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            //[StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }
            //[Required]
            //[RegularExpression("\\+\\d+", ErrorMessage = "write the phone number in the international format without spaces.")]
            //public string FullPhoneNumber { get; set; }

           
            [StringLength(6, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]

            [Display(Name = "Verification Code")]
            public string Code { get; set; }
            public bool IsValid { get; set; }
            public bool IsValidSMS { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            IEnumerable<Business> companies = await _unitOfWork.Business.GetAllAsync();
            Input = new InputModel()
            {
                CompanyList = companies.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                RoleList = _roleManager.Roles.Where(u => u.Name != SD.Role_User_Indi).Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };
            //SMSModel smsModel = new SMSModel();
            //smsModel.IsValid = false;
            SMS = new SMSModel()
            {
                IsValid = false,
                IsValidSMS = false
                
        };


            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }



        //public async Task<IActionResult> OnPostValidate(string returnUrl = null)
        //{
        //    //var ph =  Request.Form["phone"];
        //    //var Phone = HttpContext.Request.Form["phone"].ToString();
        //    returnUrl = returnUrl ?? Url.Content("~/");
        //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        //    var verification =
        //              await _verificationService.StartVerificationAsync(Input.FullPhoneNumber, "sms");
        //    if (verification.IsValid)
        //    {
        //        //return LocalRedirect(Url.Content($"~/Identity/Account/Verify/?returnUrl={returnUrl}"));
        //    }
        //    return Page();
        //}
        //public async Task<IActionResult> OnPostVerify(string returnUrl = null)
        //{
        //    returnUrl = returnUrl ?? Url.Content("~/");
        //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //    var result = await _verificationService.CheckVerificationAsync(Input.FullPhoneNumber, Input.Code);
        //    if (result.IsValid)
        //    {

        //    }
        //    return Page();
        //}


        public JsonResult CheckMobile(string userdata) 
       {
            //ApplicationUser applicationUser = new ApplicationUser();
            System.Threading.Thread.Sleep(200);
            //var SeachData = db.StudentDetails.Where(x => x.StuName == userdata).SingleOrDefault();

            var SeachData = _unitOfWork.ApplicationUser.GetFirstOrDefault(x => x.PhoneNumber == userdata);
          
            if (SeachData != null)
            {
                return new JsonResult(0);
            }
            else
            {
                return new JsonResult(1);
            }

        }


        public async Task<IActionResult> OnPostVerify(string submit, string returnUrl = null)
        {
            //var tempno = SMS.FullPhoneNumber;
            if (submit == "Sendotp")
            {
                var fullphn = SMS.PhoneNumber;
                fullphn = fullphn.Replace(" ", "");
                var matchfound = _unitOfWork.ApplicationUser.GetFirstOrDefault(x => x.PhoneNumber == fullphn);

                if (matchfound == null)
                {
                    returnUrl = returnUrl ?? Url.Content("~/");
                    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                    var verification =
                              await _verificationService.StartVerificationAsync(fullphn , "sms");
                    if (verification.IsValid)
                    {
                        SMS.IsValidSMS = true;
                        TempData["Success"] = "OTP has been sent to your Mobile";
                    }
                    if (SMS.IsValidSMS == false)
                    {
                        //ModelState.AddModelError("DuplicateNumber", "Invalid Mobile Number");
                        TempData["Success"] = "Please Enter a Valid Mobile Number";
                        return LocalRedirect(Url.Content($"~/Identity/Account/Register"));

                    }
                }
                else
                {
                   
                    //ModelState.AddModelError("DuplicateNumber", "This Number Already Exists");
                    TempData["Success"] = "Mobile Number Already Exists";
                    return LocalRedirect(Url.Content($"~/Identity/Account/Register"));

                }
                


                //return Page();
            }

            else if (submit == "Verifyotp")
            {
                returnUrl = returnUrl ?? Url.Content("~/");
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                var result = await _verificationService.CheckVerificationAsync(SMS.PhoneNumber, SMS.Code);
                if (result.IsValid)
                {
                    SMS.IsValid = true;
                    TempData["Success"] = "OTP has been verified successfully";
                }
                else
                {
                    TempData["Error"] = "Please Enter Valid OTP";
                }
            }
            return Page();
        }




        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
                returnUrl = returnUrl ?? Url.Content("~/");
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                if (ModelState.IsValid)
                {
                var fullphn = SMS.PhoneNumber;
                fullphn = fullphn.Replace(" ", "");

                    var user = new ApplicationUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email,
                        CompanyId = Input.CompanyId,
                        //StreetAddress = Input.StreetAddress,
                        //City = Input.City,
                        //State = Input.State,
                        //PostalCode = Input.PostalCode,
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        PhoneNumber = fullphn,
                        Role = Input.Role
                    };

                    var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    var role = await _roleManager.FindByNameAsync(SD.Role_User_Indi);
                    if (role == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi));
                        role = await _roleManager.FindByNameAsync(SD.Role_User_Comp);
                        if (role == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp));
                        }
                        role = await _roleManager.FindByNameAsync(SD.Role_Employee);
                        if (role == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee));
                        }
                        role = await _roleManager.FindByNameAsync(SD.Role_Admin);
                        if (role == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                        }
                    }
                
                        await _userManager.AddToRoleAsync(user, user.Role);

                        //if (user.Role == null)
                        //{
                        //    await _userManager.AddToRoleAsync(user, SD.Role_User_Indi);
                        //}
                        //else
                        //{
                        //if (user.CompanyId > 0)
                        //{
                        //    await _userManager.AddToRoleAsync(user, SD.Role_User_Comp);
                        //}
                        //await _userManager.AddToRoleAsync(user, user.Role);
                        //}

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code },
                            protocol: Request.Scheme);


                        var PathToFile = _hostEnvironment.WebRootPath + Path.DirectorySeparatorChar.ToString()
                            + "Templates" + Path.DirectorySeparatorChar.ToString() + "EmailTemplates"
                            + Path.DirectorySeparatorChar.ToString() + "Confirm_Account_Registration.html";

                        var subject = "Confirm Account Registration";
                        string HtmlBody = "";
                        using (StreamReader streamReader = System.IO.File.OpenText(PathToFile))
                        {
                            HtmlBody = streamReader.ReadToEnd();
                        }

                        //{0} : Subject  
                        //{1} : DateTime  
                        //{2} : Name  
                        //{3} : Email  
                        //{4} : Message  
                        //{5} : callbackURL  

                        string Message = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";

                        string messageBody = string.Format(HtmlBody,
                            subject,
                            String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now),
                            user.FirstName + " " + user.LastName,
                            user.Email,
                            Message,
                            callbackUrl
                            );

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email", messageBody);
                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                        }
                        else
                        {
                            if (user.Role == null)
                            {
                                await _signInManager.SignInAsync(user, isPersistent: false);
                                return LocalRedirect(returnUrl);
                            }
                            else
                            {
                                //admin is registering a new user
                                return RedirectToAction("Index", "User", new { Area = "Admin" });
                            }
                        }
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            
            
            IEnumerable<Business> companies = await _unitOfWork.Business.GetAllAsync();
            Input = new InputModel()
            {
                CompanyList = companies.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                RoleList = _roleManager.Roles.Where(u => u.Name != SD.Role_User_Indi).Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
