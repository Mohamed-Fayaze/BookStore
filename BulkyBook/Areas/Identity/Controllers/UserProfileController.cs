using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.ViewModels;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Identity.Controllers
{
    [Area("Identity")]
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private static string message;
        public UserProfileController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Upsert()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var industrylist = await _unitOfWork.Category.GetAllAsync();
            UserProfileVM userProfileVM = new UserProfileVM()
            {
                ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.Id == claim.Value),
                UserPrivate = await _unitOfWork.UserPrivate.GetFirstOrDefaultAsync(s => s.UserId == claim.Value),
                Preference = await _unitOfWork.Preference.GetFirstOrDefaultAsync(s => s.UserId == claim.Value),
                IndustryList = industrylist.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
                GenderList = GetGenderList(),
                MaritalstatusList = GetMaritalStatusList(),
                OccupationList = GetOccupationList(),
                LanguageList = GetLanguageList()
            };
            if (userProfileVM.UserPrivate == null)
            {
                userProfileVM.UserPrivate = new UserPrivate();
            }
            if (userProfileVM.Preference == null)
            {
                userProfileVM.Preference = new Preference();
            }
            return View(userProfileVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UserProfileVM userProfileVM)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\user");
                    var extenstion = Path.GetExtension(files[0].FileName);

                    if (userProfileVM.ApplicationUser.ProfilePhoto != null)
                    {
                        //this is an edit and we need to remove old image
                        var imagePath = Path.Combine(webRootPath, userProfileVM.ApplicationUser.ProfilePhoto.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    userProfileVM.ApplicationUser.ProfilePhoto = @"\images\user\" + fileName + extenstion;
                }
                else
                {
                    //update when they do not change the image

                    ApplicationUser objFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.Id == claim.Value);
                    userProfileVM.ApplicationUser.ProfilePhoto = objFromDb.ProfilePhoto;

                }
                _unitOfWork.ApplicationUser.Update(userProfileVM.ApplicationUser);
                var userprivate = await _unitOfWork.UserPrivate.GetFirstOrDefaultAsync(s => s.UserId == claim.Value);
                if (userprivate == null)
                {
                    userProfileVM.UserPrivate.UserId = claim.Value;
                    await _unitOfWork.UserPrivate.AddAsync(userProfileVM.UserPrivate);
                }
                else
                {
                    _unitOfWork.UserPrivate.Update(userProfileVM.UserPrivate);
                }
                var preference = await _unitOfWork.Preference.GetFirstOrDefaultAsync(s => s.UserId == claim.Value);

                if (preference == null)
                {
                    userProfileVM.Preference.UserId = claim.Value;
                    await _unitOfWork.Preference.AddAsync(userProfileVM.Preference);
                }
                else
                {
                    _unitOfWork.Preference.Update(userProfileVM.Preference);
                }
                var result = _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var industrylist = await _unitOfWork.Category.GetAllAsync();
            UserProfileVM userProfileVM = new UserProfileVM()
            {
                ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.Id == claim.Value),
                UserPrivate = await _unitOfWork.UserPrivate.GetFirstOrDefaultAsync(s => s.UserId == claim.Value),
                Preference = await _unitOfWork.Preference.GetFirstOrDefaultAsync(s => s.UserId == claim.Value),
                IndustryList = industrylist.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                })
            };
            if (userProfileVM.UserPrivate == null)
            {
                return RedirectToAction(nameof(Upsert));
            }

            return View(userProfileVM);
        }

        public static IEnumerable<SelectListItem> GetGenderList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Male", Value = "Male"},
                new SelectListItem{Text = "Female", Value = "Female"},
                new SelectListItem{Text = "Others", Value = "Others"}

            };
            return items;
        }

        public static IEnumerable<SelectListItem> GetMaritalStatusList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Unmarried", Value = "Unmarried"},
                new SelectListItem{Text = "Married", Value = "Married"}

            };
            return items;
        }

        public static IEnumerable<SelectListItem> GetOccupationList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Agriculture, Food and Natural Resources", Value = "Agriculture, Food and Natural Resources"},
                new SelectListItem{Text = "Architecture and Construction", Value = "Architecture and Construction"},
                new SelectListItem{Text = "Arts, Audio/Video Technology and Communications", Value = "Arts, Audio/Video Technology and Communications"},
                new SelectListItem{Text = "Business Management and Administration", Value = "Business Management and Administration"},
                new SelectListItem{Text = "Education and Training", Value = "Education and Training"},
                new SelectListItem{Text = "Finance", Value = "Finance"},
                new SelectListItem{Text = "Government and Public Administration", Value = "Government and Public Administration"},
                new SelectListItem{Text = "Health Science", Value = "Health Science"},
                new SelectListItem{Text = "Hospitality and Tourism", Value = "Hospitality and Tourism"},
                new SelectListItem{Text = "Human Services", Value = "Human Services"},
                new SelectListItem{Text = "Information Technology", Value = "Information Technology"},
                new SelectListItem{Text = "Law, Public Safety, Corrections and Security", Value = "Law, Public Safety, Corrections and Security"},
                new SelectListItem{Text = "Manufacturing", Value = "Manufacturing"},
                new SelectListItem{Text = "Marketing, Sales and Service", Value = "Marketing, Sales and Service"},
                new SelectListItem{Text = "Science, Technology, Engineering and Mathematics", Value = "Science, Technology, Engineering and Mathematics"},
                new SelectListItem{Text = "Transportation, Distribution and Logistics", Value = "Transportation, Distribution and Logistics"},

            };
            return items;
        }
        public static IEnumerable<SelectListItem> GetLanguageList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Arabic", Value = "Arabic"},
                new SelectListItem{Text = "Urdu", Value = "Urdu"},
                new SelectListItem{Text = "Hindi", Value = "Hindi"},
                new SelectListItem{Text = "Malayalam", Value = "Malayalam"},
                new SelectListItem{Text = "Tamil", Value = "Tamil"},

            };
            return items;
        }

        //public static IEnumerable<SelectListItem> GetNationalityList()
        //{
        //    IList<SelectListItem> items = new List<SelectListItem>
        //    {
        //        new SelectListItem{Text = "Syrian", Value = "Syrian"},
        //        new SelectListItem{Text = "Indian", Value = "Indian"},
        //        new SelectListItem{Text = "Pakistani", Value = "Pakistani"},
        //        new SelectListItem{Text = "Egyptian", Value = "Egyptian"},
        //        new SelectListItem{Text = "Yemeni", Value = "Yemeni"},
        //        new SelectListItem{Text = "Bangladeshi", Value = "Bangladeshi"},
        //        new SelectListItem{Text = "Filipino", Value = "Filipino"},
        //        new SelectListItem{Text = "Sri Lankan", Value = "Sri Lankan"},
        //        new SelectListItem{Text = "Indonesian", Value = "Indonesian"},
        //        new SelectListItem{Text = "Sudanese", Value = "Sudanese"},

        //    };
        //    return items;
        //}

        //public static IEnumerable<SelectListItem> GetIndustryList()
        //{
        //    IList<SelectListItem> items = new List<SelectListItem>
        //    {
        //        new SelectListItem{Text = "Syrian", Value = "U"},
        //        new SelectListItem{Text = "Indian", Value = "M"},
        //        new SelectListItem{Text = "Pakistan", Value = "M"},
        //        new SelectListItem{Text = "Egyptian", Value = "M"},
        //        new SelectListItem{Text = "Yemeni", Value = "M"},
        //        new SelectListItem{Text = "Bangladeshi", Value = "M"},
        //        new SelectListItem{Text = "Filipino", Value = "M"},
        //        new SelectListItem{Text = "Sri Lankan", Value = "M"},
        //        new SelectListItem{Text = "Indonesian", Value = "M"},
        //        new SelectListItem{Text = "Sudanese", Value = "M"},

        //    };
        //    return items;
        //}

    }
}
