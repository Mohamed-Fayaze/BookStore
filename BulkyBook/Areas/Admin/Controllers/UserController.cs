using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(ApplicationDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Verify(string id)
        {
            var industrylist = await _unitOfWork.Category.GetAllAsync();
            UserProfileVM userProfileVM = new UserProfileVM()
            {
                ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.Id == id),
                UserPrivate = await _unitOfWork.UserPrivate.GetFirstOrDefaultAsync(s => s.UserId == id),
                Preference = await _unitOfWork.Preference.GetFirstOrDefaultAsync(s => s.UserId == id),
                IndustryList = industrylist.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
                addressTable = await _unitOfWork.Address.GetAllAsync(s => s.BusinessId == null)
            };
            return View(userProfileVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(UserProfileVM userProfileVM)
        {
            if (userProfileVM.ApplicationUser.Id != null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var user = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.Id == userProfileVM.ApplicationUser.Id);
                user.IsVerified = true;
                user.VerifiedStatus = userProfileVM.ApplicationUser.VerifiedStatus;
                user.RejectedReason = userProfileVM.ApplicationUser.RejectedReason;
                user.ApprovedBy = claim.Value;
                user.ApprovedOn = DateTime.Now;
                _unitOfWork.ApplicationUser.Update(user);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _db.ApplicationUsers.Include(u => u.Company).ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Business()
                    {
                        Name = ""
                    };
                }
            }
            return Json(new { data = userList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked, we will unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Operation Successfull." });
        }

        #endregion
    }
}