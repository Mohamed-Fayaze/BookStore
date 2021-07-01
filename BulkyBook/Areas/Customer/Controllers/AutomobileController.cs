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

    public class AutomobileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AutomobileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            Automobile automobile = new Automobile();
            if (id == null)
            {
                //this is for create
                return View(automobile);
            }
            //this is for edit
            automobile = await _unitOfWork.Automobile.GetAsync(id.GetValueOrDefault());
            if (automobile == null)
            {
                return NotFound();
            }
            return View(automobile);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                if (automobile.Id == 0)
                {
                    await _unitOfWork.Automobile.AddAsync(automobile);
                }
                else
                {
                    _unitOfWork.Automobile.Update(automobile);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(automobile);
        }


        #region API CALLS

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var allObj = await _unitOfWork.Automobile.GetAllAsync();
        //    return Json(new { data = allObj });
        //}

        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var objFromDb = await _unitOfWork.Automobile.GetAsync(id);
        //    if (objFromDb == null)
        //    {
        //        TempData["Error"] = "Error deleting";
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }

        //    await _unitOfWork.Automobile.RemoveAsync(objFromDb);
        //    _unitOfWork.Save();

        //    TempData["Success"] = " successfully deleted";
        //    return Json(new { success = true, message = "Delete Successful" });

        //}
        #endregion
    }
}
