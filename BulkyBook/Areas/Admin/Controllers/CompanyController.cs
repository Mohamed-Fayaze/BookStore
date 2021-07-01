using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<BusinessType> BusinessTypeList = await _unitOfWork.BusinessType.GetAllAsync();
            IEnumerable<BulkyBook.Models.Category> PrimaryCategoryList = await _unitOfWork.Category.GetAllAsync();
            CompanyVM companyVM = new CompanyVM()
            {
                Company = new Business(),
                BusinessTypeList = BusinessTypeList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                PrimaryCategoryList = PrimaryCategoryList.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(companyVM);
            }
            //this is for edit
            companyVM.Company = await _unitOfWork.Business.GetAsync(id.GetValueOrDefault());
            if (companyVM.Company == null)
            {
                return NotFound();
            }
            return View(companyVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Business company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Business.AddAsync(company);
                }
                else
                {
                    _unitOfWork.Business.Update(company);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        public async Task<IActionResult> Verify(int Id)
        {
            BusinessProfileVM businessProfileVM = new BusinessProfileVM()
            {
                Business = await _unitOfWork.Business.GetFirstOrDefaultAsync(s => s.Id == Id, includeProperties: "ApplicationUser,BusinessType,Category"),
                BusinessHour = await _unitOfWork.BusinessHour.GetFirstOrDefaultAsync(s => s.BusinessId == Id),
                BusinessCertification = await _unitOfWork.BusinessCertification.GetAllAsync(s => s.BusinessId == Id),
                BusinessServices = await _unitOfWork.BusinessService.GetAllAsync(s => s.BusinessId == Id, includeProperties: "Services"),
                BusinessImage = await _unitOfWork.BusinessImage.GetAllAsync(s => s.BusinessId == Id),
                BusinessKeyword = await _unitOfWork.BusinessKeyword.GetFirstOrDefaultAsync(s => s.BusinessId == Id),
                BusinessPaymentModes = await _unitOfWork.BusinessPaymentMode.GetAllAsync(s => s.BusinessId == Id, includeProperties: "PaymentMode"),

                addressTable = await _unitOfWork.Address.GetAllAsync(s => s.BusinessId == Id),
                mobileTable = await _unitOfWork.Mobile.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                emailTable = await _unitOfWork.Email.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                landlineTable = await _unitOfWork.Landline.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                locationTable = await _unitOfWork.Location.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                socialTable = await _unitOfWork.Social.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address")
            };

            return View(businessProfileVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(BusinessProfileVM businessProfileVM)
        {
            if (businessProfileVM.Business.Id != 0)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var business = await _unitOfWork.Business.GetFirstOrDefaultAsync(s => s.Id == businessProfileVM.Business.Id);
                business.IsVerified = true;
                business.VerifiedStatus = businessProfileVM.Business.VerifiedStatus;
                business.RejectedReason = businessProfileVM.Business.RejectedReason;
                business.ApprovedBy = claim.Value;
                business.ApprovedOn = DateTime.Now;
                _unitOfWork.Business.Update(business);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Business.GetAllAsync(orderBy: s => s.OrderByDescending(s => s.CreatedOn));
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Business.GetAsync(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var objfromaddress = await _unitOfWork.Address.GetFirstOrDefaultAsync(s => s.BusinessId == id);
            var objfromreview = _unitOfWork.ReviewRating.GetFirstOrDefault(s => s.BussinessId == id);
            var objfromfaq = _unitOfWork.FAQ.GetFirstOrDefault(s => s.BussinessId == id);
            var objfromcert = await _unitOfWork.BusinessCertification.GetAllAsync(s => s.BusinessId == id);
            var objfromimgs = await _unitOfWork.BusinessImage.GetAllAsync(s => s.BusinessId == id);
            if (objFromDb.ProfilePhoto != null)
            {
                deletefile(objFromDb.ProfilePhoto);
            }
            //if (objFromDb.ProofDocument != null)
            //{
            //    deletefile(objFromDb.ProofDocument);
            //}
            foreach (var item in objfromcert)
            {
                if (item.Certificate != null)
                {
                    deletefile(item.Certificate);
                }
            }
            foreach (var item in objfromimgs)
            {
                if (item.Image != null)
                {
                    deletefile(item.Image);
                }
            }
            await _unitOfWork.Address.RemoveAsync(objfromaddress);
             _unitOfWork.ReviewRating.Remove(objfromreview);
             _unitOfWork.FAQ.Remove(objfromfaq);

            await _unitOfWork.Business.RemoveAsync(objFromDb);
            var result = _unitOfWork.Save();
            if (!result)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            return Json(new { success = true, message = "Delete Successful" });
        }
        private void deletefile(string imgpath)
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, imgpath.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        #endregion
    }
}