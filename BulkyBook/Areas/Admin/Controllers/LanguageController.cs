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
 
    public class LanguageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LanguageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            Language language = new Language();
            if (id == null)
            {
                //this is for create
                return View(language);
            }
            //this is for edit
            language = await _unitOfWork.Language.GetAsync(id.GetValueOrDefault());
            if (language == null)
            {
                return NotFound();
            }
            return View(language);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Language language)
        {
            if (ModelState.IsValid)
            {
                if (language.Id == 0)
                {
                    await _unitOfWork.Language.AddAsync(language);
                }
                else
                {
                    _unitOfWork.Language.update(language);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Language.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Language.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.Language.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
