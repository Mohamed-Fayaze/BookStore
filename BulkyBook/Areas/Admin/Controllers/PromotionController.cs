using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.ViewModels;
using BulkyBook.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PromotionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PromotionController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var businesslist = await _unitOfWork.Business.GetAllAsync(s => s.UserId == claim.Value);
            PromotionVM promotionVM = new PromotionVM
            {
                Promotion = new Promotion(),
                BusinessList = businesslist.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null)
            {
                //this is for create
                return View(promotionVM);
            }

            //this is for edit
            promotionVM.Promotion = _unitOfWork.Promotion.Get(id.GetValueOrDefault());
            if (promotionVM.Promotion == null)
            {
                return NotFound();
            }
            promotionVM.Promotionimages = await _unitOfWork.Promotionimage.GetAllAsync(s => s.PromotionId == promotionVM.Promotion.Id);
            return View(promotionVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PromotionVM promotionVM)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    promotionVM.Promotionimages = Enumerable.Empty<Promotionimage>();
                    for (int i = 0; i < files.Count; i++)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        Promotionimage promotionimage = new Promotionimage();
                        var uploads = Path.Combine(webRootPath, @"images\Promotion");
                        var extenstion = Path.GetExtension(files[i].FileName);
                        using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                        {
                            files[i].CopyTo(filesStreams);
                        }
                        promotionimage.Images = @"\images\Promotion\" + fileName + extenstion;
                        promotionVM.Promotionimages = promotionVM.Promotionimages.Concat(new[] { promotionimage });
                    }
                }


                if (promotionVM.Promotion.Id == 0)
                {
                    _unitOfWork.Promotion.Add(promotionVM.Promotion);
                    _unitOfWork.Save();
                    if (promotionVM.Promotionimages != null)
                    {
                        foreach (var item in promotionVM.Promotionimages)
                        {
                            item.PromotionId = promotionVM.Promotion.Id;
                        }
                        if (promotionVM.Promotionimages.Count() > 0)
                        {
                            await _unitOfWork.Promotionimage.AddRangeAsync(promotionVM.Promotionimages);
                        }
                    }
                }
                else
                {
                    _unitOfWork.Promotion.Update(promotionVM.Promotion);

                    if (promotionVM.Promotionimages != null)
                    {
                        foreach (var item in promotionVM.Promotionimages)
                        {
                            item.PromotionId = promotionVM.Promotion.Id;
                        }
                        if (promotionVM.Promotionimages.Count() > 0)
                        {
                            await _unitOfWork.Promotionimage.AddRangeAsync(promotionVM.Promotionimages);
                        }
                    }
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(promotionVM.Promotion);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Promotion.GetAll(includeProperties: "Business");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Promotion.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error deleting" });
            }
            //string webRootPath = _hostEnvironment.WebRootPath;
            //var imagePath = Path.Combine(webRootPath, objFromDb.UploadFile.TrimStart('\\'));
            //if (System.IO.File.Exists(imagePath))
            //{
            //    System.IO.File.Delete(imagePath);
            //}
            _unitOfWork.Promotion.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}