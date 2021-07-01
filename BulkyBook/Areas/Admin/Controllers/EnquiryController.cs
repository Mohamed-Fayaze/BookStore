using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class EnquiryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnquiryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int businessId)
        {
            Enquiry enquiry = new Enquiry();
            enquiry.BusinessId = businessId;
            return View(enquiry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                if (enquiry.Id == 0)
                {
                    var claimsIdentity = (ClaimsIdentity)User.Identity;
                    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                    enquiry.UserId = claim.Value;
                    enquiry.CreatedOn = DateTime.Now;
                    _unitOfWork.Enquiry.Add(enquiry);
                }
                _unitOfWork.Save();
                return LocalRedirect("/Customer/Home/DetailLive?Id=" + enquiry.BusinessId);
            }
            return View(enquiry);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Enquiry.GetAll();
            return Json(new { data = allObj });
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDb = _unitOfWork.Enquiry.Get(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }
        //    _unitOfWork.Enquiry.Remove(objFromDb);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete Successful" });

        //}

        #endregion
    }
}