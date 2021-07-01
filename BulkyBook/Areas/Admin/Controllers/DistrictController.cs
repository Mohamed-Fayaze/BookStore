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

    public class DistrictController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DistrictController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            District district = new District();
            var stateList = await _unitOfWork.State.GetAllAsync();
            if (id == null)
            {
                //this is for create
                district.StateList = stateList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(district);
            }
            //this is for edit
            district = await _unitOfWork.District.GetAsync(id.GetValueOrDefault());
            if (district == null)
            {
                return NotFound();
            }
            district.StateList = stateList.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return View(district);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(District district)
        {
            if (ModelState.IsValid)
            {
                if (district.Id == 0)
                {
                    await _unitOfWork.District.AddAsync(district);
                }
                else
                {
                    _unitOfWork.District.Update(district);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(district);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.District.GetAllAsync(includeProperties:"State");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.District.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.District.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
