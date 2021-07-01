using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OtherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OtherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            
            Other other = new Other();
            var categoryList = await _unitOfWork.Category.GetAllAsync();
            other.CategoryList = categoryList.Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.CategoryId.ToString()
            });
            if (id == null)
            {
                //this is for create
                return View(other);
            }
            //this is for edit
            other = _unitOfWork.Other.Get(id.GetValueOrDefault());
            other.CategoryList = categoryList.Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.CategoryId.ToString()
            });
            if (other == null)
            {
                return NotFound();
            }
            return View(other);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Other other)
        {
            if (ModelState.IsValid)
            {
                if (other.Id== 0)
                {
                    _unitOfWork.Other.Add(other);
                    
                }
                else
                {
                    _unitOfWork.Other.Update(other);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(other);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Other.GetAll(includeProperties: "Category");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Other.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Other.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}