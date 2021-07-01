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
 
    public class HospitaldepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HospitaldepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            HospitalDepartment hospitaldepartment = new HospitalDepartment();
            if (id == null)
            {
                //this is for create
                return View(hospitaldepartment);
            }
            //this is for edit
          hospitaldepartment = await _unitOfWork.Hospitaldepartment.GetAsync(id.GetValueOrDefault());
            if (hospitaldepartment == null)
            {
                return NotFound();
            }
            return View(hospitaldepartment);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(HospitalDepartment hospitaldepartment)
        {
            if (ModelState.IsValid)
            {
                if (hospitaldepartment.Id == 0)
                {
                    await _unitOfWork.Hospitaldepartment.AddAsync(hospitaldepartment);
                }
                else
                {
                    _unitOfWork.Hospitaldepartment.update(hospitaldepartment);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(hospitaldepartment);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Hospitaldepartment.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Hospitaldepartment.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.Hospitaldepartment.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
