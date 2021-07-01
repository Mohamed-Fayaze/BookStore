using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PaymentModeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentModeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index(int productPage = 1)
        {
            PaymentModeVM paymentModeVM = new PaymentModeVM()
            {
                PaymentModes = await _unitOfWork.PaymentMode.GetAllAsync()
            };
            var count = paymentModeVM.PaymentModes.Count();
            paymentModeVM.PaymentModes = paymentModeVM.PaymentModes.OrderBy(p => p.Name)
                .Skip((productPage - 1) * 2).Take(2).ToList();

            paymentModeVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = 2,
                TotalItem = count,
                urlParam = "/Admin/PaymentMode/Index?productPage=:"
            };

            return View(paymentModeVM);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            PaymentMode paymentMode = new PaymentMode();
            if (id == null)
            {
                //this is for create
                return View(paymentMode);
            }
            //this is for edit
            paymentMode = await _unitOfWork.PaymentMode.GetAsync(id.GetValueOrDefault());
            if (paymentMode == null)
            {
                return NotFound();
            }
            return View(paymentMode);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PaymentMode paymentMode)
        {
            if (ModelState.IsValid)
            {
                if (paymentMode.Id == 0)
                {
                    await _unitOfWork.PaymentMode.AddAsync(paymentMode);
                }
                else
                {
                    _unitOfWork.PaymentMode.Update(paymentMode);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMode);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.PaymentMode.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            var objFromDb = await _unitOfWork.PaymentMode.GetAsync(id.GetValueOrDefault());
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting Payment Mode";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.PaymentMode.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Payment Mode successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
