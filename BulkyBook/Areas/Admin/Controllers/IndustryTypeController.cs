
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.Utility;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class IndustryTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndustryTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            IndustryType industryType = new IndustryType();
            if (id == null)
            {
                //this is for create
                return View(industryType);
            }
            //this is for edit
            industryType = await _unitOfWork.IndustryType.GetAsync(id.GetValueOrDefault());
            if (industryType == null)
            {
                return NotFound();
            }
            return View(industryType);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(IndustryType industryType)
        {
            if (ModelState.IsValid)
            {
                if (industryType.Id == 0)
                {
                    await _unitOfWork.IndustryType.AddAsync(industryType);
                }
                else
                {
                    _unitOfWork.IndustryType.update(industryType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(industryType);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.IndustryType.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.IndustryType.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.IndustryType.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
