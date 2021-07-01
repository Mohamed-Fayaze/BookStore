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
    public class ReportasinaccurateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportasinaccurateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int businessId)
        {
            Reportasinaccurate reportasinaccurate = new Reportasinaccurate();
            reportasinaccurate.BusinessId = businessId;
            return View(reportasinaccurate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Reportasinaccurate reportasinaccurate)
        {
            if (ModelState.IsValid)
            {
                if (reportasinaccurate.Id == 0)
                {
                    var claimsIdentity = (ClaimsIdentity)User.Identity;
                    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                    reportasinaccurate.UserId = claim.Value;
                    reportasinaccurate.CreatedOn = DateTime.Now;
                    _unitOfWork.Reportasinaccurate.Add(reportasinaccurate);
                }
                _unitOfWork.Save();
                return LocalRedirect("/Customer/Home/DetailLive?Id=" + reportasinaccurate.BusinessId);
            }
            return View(reportasinaccurate);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Reportasinaccurate.GetAll();
            return Json(new { data = allObj });
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDb = _unitOfWork.Reportasinaccurate.Get(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }
        //    _unitOfWork.Reportasinaccurate.Remove(objFromDb);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete Successful" });

        //}

        #endregion
    }
}