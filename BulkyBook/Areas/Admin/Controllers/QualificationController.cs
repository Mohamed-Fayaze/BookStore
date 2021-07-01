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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class QualificationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public QualificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            Qualification qualification = new Qualification();
            var categoryList = await _unitOfWork.Category.GetAllAsync();
            qualification.categoryList = categoryList.Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.CategoryId.ToString()
            });
            if (id == null)
            {
                //this is for create
                return View(qualification);
            }
            //this is for edit
            qualification = await _unitOfWork.Qualification.GetAsync(id.GetValueOrDefault());
            qualification.categoryList = categoryList.Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.CategoryId.ToString()
            });
            if (qualification == null)
            {
                return NotFound();
            }
            return View(qualification);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                if (qualification.Id == 0)
                {
                    await _unitOfWork.Qualification.AddAsync(qualification);
                }
                else
                {
                    _unitOfWork.Qualification.Update(qualification);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(qualification);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Qualification.GetAllAsync(includeProperties: "Category");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Qualification.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.Qualification.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
