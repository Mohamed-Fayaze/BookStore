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
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class BusinessTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BusinessTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index(int productPage=1)
        {
            BusinessTypeVM businessTypeVM = new BusinessTypeVM()
            {
                BusinessTypes = await _unitOfWork.BusinessType.GetAllAsync()
            };
            var count = businessTypeVM.BusinessTypes.Count();
            businessTypeVM.BusinessTypes = businessTypeVM.BusinessTypes.OrderBy(p => p.Name)
                .Skip((productPage - 1) * 2).Take(2).ToList();

            businessTypeVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = 2,
                TotalItem = count,
                urlParam = "/Admin/BusinessType/Index?productPage=:"
            }; 

            return View(businessTypeVM);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            BusinessType businessType = new BusinessType();
            if (id == null)
            {
                //this is for create
                return View(businessType);
            }
            //this is for edit
            businessType = await _unitOfWork.BusinessType.GetAsync(id.GetValueOrDefault());
            if (businessType == null)
            {
                return NotFound();
            }
            return View(businessType);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BusinessType businessType)
        {
            if (ModelState.IsValid)
            {
                if (businessType.Id == 0)
                {
                    await _unitOfWork.BusinessType.AddAsync(businessType);
                }
                else
                {
                    _unitOfWork.BusinessType.Update(businessType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(businessType);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.BusinessType.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.BusinessType.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting Business Type";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.BusinessType.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Business Type successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
