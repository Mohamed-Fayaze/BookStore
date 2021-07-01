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

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<IActionResult> Index(int productPage = 1)
        {
            string role = HttpContext.Session.GetString("Role");

            ServicesVM servicesVM = new ServicesVM()
            {
                Services = await _unitOfWork.Services.GetAllAsync()
            };
            var count = servicesVM.Services.Count();
            servicesVM.Services = servicesVM.Services.OrderBy(p => p.Name)
                .Skip((productPage - 1) * 2).Take(2).ToList();

            servicesVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = 2,
                TotalItem = count,
                urlParam = "/Admin/Services/Index?productPage=:"
            };

            return View(servicesVM);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Services services = new Services();
            if (id == null)
            {
                //this is for create
                return View(services);
            }
            //this is for edit
            services = await _unitOfWork.Services.GetAsync(id.GetValueOrDefault());
            if (services == null)
            {
                return NotFound();
            }
            return View(services);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Services services)
        {
            if (ModelState.IsValid)
            {
                if (services.Id == 0)
                {
                    await _unitOfWork.Services.AddAsync(services);
                }
                else
                {
                    _unitOfWork.Services.Update(services);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(services);
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Services.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            var objFromDb = await _unitOfWork.Services.GetAsync(id.GetValueOrDefault());
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting Category";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.Services.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Category successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
