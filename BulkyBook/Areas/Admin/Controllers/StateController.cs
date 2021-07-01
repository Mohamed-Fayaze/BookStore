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

    public class StateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            State state = new State();

            if (id == null)
            {
                //this is for create
                return View(state);
            }
            //this is for edit
            state = await _unitOfWork.State.GetAsync(id.GetValueOrDefault());

            if (state == null)
            {
                return NotFound();
            }
            return View(state);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(State state)
        {
            if (ModelState.IsValid)
            {
                if (state.Id == 0)
                {
                    await _unitOfWork.State.AddAsync(state);
                }
                else
                {
                    _unitOfWork.State.Update(state);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.State.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.State.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.State.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
