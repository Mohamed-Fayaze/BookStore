using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.Models.ViewModels;


namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IWebHostEnvironment _hostEnvironment;



        public SubCategoryController(IUnitOfWork unitOfwork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfwork = unitOfwork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<BulkyBook.Models.Category> primaryList = await _unitOfwork.Category.GetAllAsync();
            CategoryVM primaryVM = new CategoryVM()
            {
               
               categorylist= primaryList.Select(i=> new SelectListItem
               {
                   Text=i.CategoryName,
                   Value=i.CategoryId.ToString()
               }),
                
            };
            //SubCategory subCategory = new SubCategory();
            
            if (id == null)
            {
                primaryVM.SubCategory = new SubCategory();
                //categorylist.SubCategory = subCategory;
                return View(primaryVM);
                 
            }

            primaryVM.SubCategory = await _unitOfwork.SubCategory.GetAsync(id.GetValueOrDefault());
            if (primaryVM.SubCategory == null)
            {
                return NotFound();
            }
            return View(primaryVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CategoryVM primaryVM)
        {
            if (ModelState.IsValid)
            {
                String webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\products");
                    var extension = Path.GetExtension(files[0].FileName);

                    if (primaryVM.SubCategory.SubCategoryIcon != null)
                    {
                        var imagepath = Path.Combine(webRootPath, primaryVM.SubCategory.SubCategoryIcon.TrimStart('\\'));
                        if (System.IO.File.Exists(imagepath))
                        {
                            System.IO.File.Delete(imagepath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }
                    primaryVM.SubCategory.SubCategoryIcon = @"\images\products\" + fileName + extension;

                    //new image 
                    fileName = Guid.NewGuid().ToString();
                    extension = Path.GetExtension(files[1].FileName);
                    if (primaryVM.SubCategory.SubCategoryImage != null)
                    {
                        var imagepaths = Path.Combine(webRootPath, primaryVM.SubCategory.SubCategoryImage.TrimStart('\\'));
                        if (System.IO.File.Exists(imagepaths))
                        {
                            System.IO.File.Delete(imagepaths);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[1].CopyTo(fileStreams);
                    }
                    primaryVM.SubCategory.SubCategoryImage = @"\images\products\" + fileName + extension;
                }


                if (primaryVM.SubCategory.SecondaryId == 0)
                {
                   await _unitOfwork.SubCategory.AddAsync(primaryVM.SubCategory);

                }
                else
                {
                    _unitOfwork.SubCategory.update(primaryVM.SubCategory);
                }
                _unitOfwork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                IEnumerable<BulkyBook.Models.Category> categoryList = await _unitOfwork.Category.GetAllAsync();
                primaryVM.categorylist = categoryList.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                });

                if (primaryVM.SubCategory.SecondaryId == 0)
                {
                    primaryVM.SubCategory = await _unitOfwork.SubCategory.GetAsync(primaryVM.SubCategory.SecondaryId);
                }
            }
            return View(primaryVM);
        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allobj = _unitOfwork.SubCategory.GetAllAsync(includeProperties: "PrimaryCategory");
            return Json(new { data = allobj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb =await _unitOfwork.SubCategory.GetAsync(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.SubCategoryIcon.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            var imagePaths = Path.Combine(webRootPath, objFromDb.SubCategoryImage.TrimStart('\\'));
            if (System.IO.File.Exists(imagePaths))
            {
                System.IO.File.Delete(imagePaths);
            }

            await _unitOfwork.SubCategory.RemoveAsync(objFromDb);
            _unitOfwork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }


        #endregion
    }
}
