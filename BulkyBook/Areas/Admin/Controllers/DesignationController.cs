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

    public class DesignationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DesignationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            Designation designation = new Designation();
            var categoryList = await _unitOfWork.Category.GetAllAsync();
            designation.categoryList = categoryList.Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.CategoryId.ToString()
            });
            if (id == null)
            {
                //this is for create
                return View(designation);
            }
            //this is for edit
            designation = await _unitOfWork.Designation.GetAsync(id.GetValueOrDefault());
            designation.categoryList = categoryList.Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.CategoryId.ToString()
            });
            if (designation == null)
            {
                return NotFound();
            }
            return View(designation);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Designation designation)
        {
            if (ModelState.IsValid)
            {
                if (designation.Id == 0)
                {
                    await _unitOfWork.Designation.AddAsync(designation);
                }
                else
                {
                    _unitOfWork.Designation.Update(designation);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(designation);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Designation.GetAllAsync(includeProperties: "Category");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Designation.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.Designation.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
