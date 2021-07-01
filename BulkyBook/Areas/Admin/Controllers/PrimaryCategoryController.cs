using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrimaryCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IWebHostEnvironment _hostEnvironment;



        public PrimaryCategoryController(IUnitOfWork unitOfwork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfwork = unitOfwork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {

            return View();

        }
        //public IActionResult view()
        //{

        //    return View();

        //}
        public async Task<IActionResult> Home(string search, string location)
        {
            ViewData["searchval"] = search;
            ViewData["location"] = location;
            if (location != "")
            {
                var state = await _unitOfwork.State.GetFirstOrDefaultAsync(s => s.Name.ToLower().Contains(location.ToLower()));
                ViewData["State"] = state.Id;
            }
            CategoryVM primaryVM = new CategoryVM();
            primaryVM.primaries = await _unitOfwork.Category.GetAllAsync();
            primaryVM.secondaries =await _unitOfwork.SubCategory.GetAllAsync();
            return View(primaryVM);
        }
        //public IActionResult second(string search)
        //{

        //    CategoryList categoryList = new CategoryList();



        //    return View(categoryList);

        //}
        public async Task<IActionResult> Upsert(int? id)
        {

            BulkyBook.Models.Category primaryCategory = new BulkyBook.Models.Category();
            if (id == null)
            {
                //PrimaryCategory primaryCategory = new PrimaryCategory();
                //primaryVM.PrimaryCategory = primaryCategory;

                return View(primaryCategory);
            }

            primaryCategory =await _unitOfwork.Category.GetAsync(id.GetValueOrDefault());
            if (primaryCategory == null)
            {
                return NotFound();
            }
            return View(primaryCategory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BulkyBook.Models.Category primaryCategory)
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

                    if (primaryCategory.CategoryIcon != null)
                    {
                        var imagepath = Path.Combine(webRootPath, primaryCategory.CategoryIcon.TrimStart('\\'));
                        if (System.IO.File.Exists(imagepath))
                        {
                            System.IO.File.Delete(imagepath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    primaryCategory.CategoryIcon = @"\images\products\" + fileName + extension;


                //}



                //else
                //{

                //    //update when they do not change the image
                //    if (primaryVM.PrimaryCategory.CategoryId != 0)
                //    {
                //        PrimaryCategory objFromDb = _unitOfwork.PrimaryCategory.Get(primaryVM.PrimaryCategory.CategoryId);
                //        primaryVM.PrimaryCategory.CategoryIcon = objFromDb.CategoryIcon;
                //    }

                //}  
                //new image 
                files = HttpContext.Request.Form.Files;
                    if (files.Count > 1)
                    {
                        fileName = Guid.NewGuid().ToString();

                        //var uploads = Path.Combine(webRootPath, @"images\products");


                        extension = Path.GetExtension(files[1].FileName);

                        if (primaryCategory.CategoryImage != null)
                        {
                            var imagepaths = Path.Combine(webRootPath, primaryCategory.CategoryImage.TrimStart('\\'));
                            if (System.IO.File.Exists(imagepaths))
                            {
                                System.IO.File.Delete(imagepaths);
                            }
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[1].CopyTo(fileStreams);
                        }
                        primaryCategory.CategoryImage = @"\images\products\" + fileName + extension;

                    }
                }

                if (primaryCategory.CategoryId == 0)
                {
                    _unitOfwork.Category.AddAsync(primaryCategory);

                }
                else
                {
                    _unitOfwork.Category.update(primaryCategory);
                }
                _unitOfwork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(primaryCategory);
        }



        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allobj = await _unitOfwork.Category.GetAllAsync();
            return Json(new { data = allobj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb =await _unitOfwork.Category.GetAsync(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string webRootPath = _hostEnvironment.WebRootPath;
            if (objFromDb.CategoryIcon != null)
            {
                var imagePath = Path.Combine(webRootPath, objFromDb.CategoryIcon.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            if (objFromDb.CategoryImage != null)
            {
                var imagePaths = Path.Combine(webRootPath, objFromDb.CategoryImage.TrimStart('\\'));
                if (System.IO.File.Exists(imagePaths))
                {
                    System.IO.File.Delete(imagePaths);
                }
            }

           await _unitOfwork.Category.RemoveAsync(objFromDb);
            _unitOfwork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }


        #endregion
    }
}

