using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BulkyBook.Areas.Identity.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class BusinessProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private static string message;
        public BusinessProfileController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Upsert(string category,int? Id)
        {
            IEnumerable<BusinessType> BusinessTypeList = await _unitOfWork.BusinessType.GetAllAsync();
            //IEnumerable<BulkyBook.Models.Category> PrimaryCategoryList = await _unitOfWork.Category.GetAllAsync();
            //IEnumerable<PaymentMode> PaymentModeList = await _unitOfWork.PaymentMode.GetAllAsync();
            //IEnumerable<Services> ServicesList = await _unitOfWork.Services.GetAllAsync();
            ViewData["category"] = category;
            var categoryId = 0;
            var subCategoryId = 0;
            var subcategory = await _unitOfWork.SubCategory.GetFirstOrDefaultAsync(s=>s.SecondaryName.Contains(category));
            if (subcategory != null)
            {
                categoryId = subcategory.CategoryId;
                subCategoryId = subcategory.SecondaryId;
            }
            BusinessProfileVM businessProfileVM = new BusinessProfileVM()
            {
                Business = new Business(),
                //BusinessKeyword = new BusinessKeyword(),
                BusinessTypeList = BusinessTypeList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                //PrimaryCategoryList = PrimaryCategoryList.Select(i => new SelectListItem
                //{
                //    Text = i.CategoryName,
                //    Value = i.CategoryId.ToString()
                //}),
                //PaymentModeList = PaymentModeList.Select(i => new SelectListItem
                //{
                //    Text = i.Name,
                //    Value = i.Id.ToString()
                //}),
                //ServicesList = ServicesList.Select(i => new SelectListItem
                //{
                //    Text = i.Name,
                //    Value = i.Id.ToString()
                //}),
            };
            if (Id == null)
            {
                businessProfileVM.Business.CategoryId = categoryId;
                businessProfileVM.Business.SubCategoryId = subCategoryId;
                //this is for create
                //businessProfileVM.BusinessCertification = Enumerable.Empty<BusinessCertification>();
                //businessProfileVM.BusinessImage = Enumerable.Empty<BusinessImage>();
                //businessProfileVM.BusinessPaymentModes = Enumerable.Empty<BusinessPaymentMode>();
                //businessProfileVM.BusinessServices = Enumerable.Empty<BusinessService>();
                return View(businessProfileVM);
            }
            //For Edit
            businessProfileVM.Business = await _unitOfWork.Business.GetFirstOrDefaultAsync(s => s.Id == Id);
            //businessProfileVM.BusinessServices = await _unitOfWork.BusinessService.GetAllAsync(s => s.BusinessId == Id);
            //businessProfileVM.BusinessHour = await _unitOfWork.BusinessHour.GetFirstOrDefaultAsync(s => s.BusinessId == Id);
            //businessProfileVM.BusinessCertification = await _unitOfWork.BusinessCertification.GetAllAsync(s => s.BusinessId == Id);
            //businessProfileVM.BusinessPaymentModes = await _unitOfWork.BusinessPaymentMode.GetAllAsync(s => s.BusinessId == Id);
            //businessProfileVM.BusinessImage = await _unitOfWork.BusinessImage.GetAllAsync(s => s.BusinessId == Id);
            //businessProfileVM.BusinessKeyword = await _unitOfWork.BusinessKeyword.GetFirstOrDefaultAsync(s => s.BusinessId == Id);
            return View(businessProfileVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BusinessProfileVM businessProfileVM, string category)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                string webRootPath = _hostEnvironment.WebRootPath;
                //files operation
                var files = HttpContext.Request.Form.Files;
                //bool Isprofileupdated = false;
                if (files.Count > 0)
                {
                    businessProfileVM.BusinessCertification = Enumerable.Empty<BusinessCertification>();
                    businessProfileVM.BusinessImage = Enumerable.Empty<BusinessImage>();
                    for (int i = 0; i < files.Count; i++)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var extension = Path.GetExtension(files[i].FileName);
                        var uploads = string.Empty;
                       
                        switch (files[i].Name)
                        {
                            case "Profile":
                                
                                uploads = Path.Combine(webRootPath, @"images\business\profile");
                                if (businessProfileVM.Business.ProfilePhoto != null)
                                {
                                    //this is an edit and we need to remove old image
                                    var imagePath = Path.Combine(webRootPath, businessProfileVM.Business.ProfilePhoto.TrimStart('\\'));
                                    if (System.IO.File.Exists(imagePath))
                                    {
                                        System.IO.File.Delete(imagePath);
                                    }
                                }
                                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                                {
                                    files[i].CopyTo(filesStreams);
                                }
                                businessProfileVM.Business.ProfilePhoto = @"\images\business\profile\" + fileName + extension;
                                //Isprofileupdated = true;
                                break;

                            //case "Certificate":

                            //    BusinessCertification businessCertification = new BusinessCertification();
                            //    uploads = Path.Combine(webRootPath, @"images\business\certificate");
                            //    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                            //    {
                            //        files[i].CopyTo(filesStreams);
                            //    }
                            //    businessCertification.Certificate = @"\images\business\certificate\" + fileName + extension;
                            //    businessProfileVM.BusinessCertification = businessProfileVM.BusinessCertification.Concat(new[] { businessCertification });
                            //    break;

                            //case "ProofDocument":

                            //    uploads = Path.Combine(webRootPath, @"images\business\proofdocument");
                            //    if (businessProfileVM.Business.ProofDocument != null)
                            //    {
                            //        //this is an edit and we need to remove old image
                            //        var imagePath = Path.Combine(webRootPath, businessProfileVM.Business.ProfilePhoto.TrimStart('\\'));
                            //        if (System.IO.File.Exists(imagePath))
                            //        {
                            //            System.IO.File.Delete(imagePath);
                            //        }
                            //    }
                            //    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                            //    {
                            //        files[i].CopyTo(filesStreams);
                            //    }
                            //    businessProfileVM.Business.ProofDocument = @"\images\business\proofdocument\" + fileName + extension;
                            //    break;

                            //case "businessimage":

                            //    BusinessImage businessImage = new BusinessImage();
                            //    uploads = Path.Combine(webRootPath, @"images\business\image");
                            //    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                            //    {
                            //        files[i].CopyTo(filesStreams);
                            //    }
                            //    businessImage.Image = @"\images\business\image\" + fileName + extension;
                            //    businessProfileVM.BusinessImage = businessProfileVM.BusinessImage.Concat(new[] { businessImage });
                            //    break;
                        }
                    }
                }
                //Data operation
                //var serviceslist = HttpContext.Request.Form["service"];
                //var paymenmodeslist = HttpContext.Request.Form["paymentMode"];
                if (businessProfileVM.Business.Id == 0)
                {
                    businessProfileVM.Business.UserId = claim.Value;
                    businessProfileVM.Business.CreatedOn = DateTime.Now;
                    businessProfileVM.Business.LastOperation = 'I';
                    businessProfileVM.Business.LastOperationOn = DateTime.Now;
                    await _unitOfWork.Business.AddAsync(businessProfileVM.Business);
                    var result = _unitOfWork.Save();
                    if (result)
                    {
                        var businessId = businessProfileVM.Business.Id;
                        //if (!string.IsNullOrEmpty(businessProfileVM.BusinessKeyword.Description))
                        //{
                        //    businessProfileVM.BusinessKeyword.BusinessId = businessId;
                        //    await _unitOfWork.BusinessKeyword.AddAsync(businessProfileVM.BusinessKeyword);
                        //}
                        //businessProfileVM.BusinessHour.BusinessId = businessId;
                        //await _unitOfWork.BusinessHour.AddAsync(businessProfileVM.BusinessHour);
                        //if (businessProfileVM.BusinessCertification != null)
                        //{
                        //    foreach (var item in businessProfileVM.BusinessCertification)
                        //    {
                        //        item.BusinessId = businessId;
                        //    }
                        //    if (businessProfileVM.BusinessCertification.Count() > 0)
                        //    {
                        //        await _unitOfWork.BusinessCertification.AddRangeAsync(businessProfileVM.BusinessCertification);
                        //    }
                        //}
                        //if (businessProfileVM.BusinessImage != null)
                        //{
                        //    foreach (var item in businessProfileVM.BusinessImage)
                        //    {
                        //        item.BusinessId = businessId;
                        //    }
                        //    if (businessProfileVM.BusinessImage.Count() > 0)
                        //    {
                        //        await _unitOfWork.BusinessImage.AddRangeAsync(businessProfileVM.BusinessImage);
                        //    }
                        //}

                        //var serviceList =(serviceslist.ToString().Split(','));
                        //if (serviceList.Length > 0)
                        //{
                        //    foreach (var item in serviceList)
                        //    {
                        //        if (!string.IsNullOrEmpty(item))
                        //        {
                        //            BusinessService businessService = new BusinessService();
                        //            businessService.BusinessId = businessId;
                        //            businessService.ServicesId = Convert.ToInt32(item);
                        //            await _unitOfWork.BusinessService.AddAsync(businessService);
                        //        }
                        //    }
                        //}
                        //var paymentModeList = paymenmodeslist.ToString().Split(',');
                        //if (paymentModeList.Length > 0)
                        //{
                        //    foreach (var item in paymentModeList)
                        //    {
                        //        if (!string.IsNullOrEmpty(item))
                        //        {
                        //            BusinessPaymentMode businessPaymentMode = new BusinessPaymentMode();
                        //            businessPaymentMode.BusinessId = businessId;
                        //            businessPaymentMode.PaymentModeId = Convert.ToInt32(item);
                        //            await _unitOfWork.BusinessPaymentMode.AddAsync(businessPaymentMode);
                        //        }
                        //    }
                        //}
                        result = _unitOfWork.Save();
                        return LocalRedirect("/Customer/AddressTables/Index?businessid=" + businessId + "&category=" + category);
                    }
                }
                else
                {
                    businessProfileVM.Business.LastOperation = 'U';
                    businessProfileVM.Business.LastOperationOn = DateTime.Now;
                    _unitOfWork.Business.Update(businessProfileVM.Business);
                    var businessId = businessProfileVM.Business.Id;
                    //if (!string.IsNullOrEmpty(businessProfileVM.BusinessKeyword.Description))
                    //{
                    //    businessProfileVM.BusinessKeyword.BusinessId = businessId;
                    //    await _unitOfWork.BusinessKeyword.AddAsync(businessProfileVM.BusinessKeyword);
                    //}
                    //_unitOfWork.BusinessHour.Update(businessProfileVM.BusinessHour);
                    //if (businessProfileVM.BusinessCertification != null)
                    //{
                    //    foreach (var item in businessProfileVM.BusinessCertification)
                    //    {
                    //        item.BusinessId = businessId;
                    //    }
                    //    if (businessProfileVM.BusinessCertification.Count() > 0)
                    //    {
                    //        await _unitOfWork.BusinessCertification.AddRangeAsync(businessProfileVM.BusinessCertification);
                    //    }
                    //}
                    //if (businessProfileVM.BusinessImage != null)
                    //{
                    //    foreach (var item in businessProfileVM.BusinessImage)
                    //    {
                    //        item.BusinessId = businessId;
                    //    }
                    //    if (businessProfileVM.BusinessImage.Count() > 0)
                    //    {
                    //        await _unitOfWork.BusinessImage.AddRangeAsync(businessProfileVM.BusinessImage);
                    //    }
                    //}
                    //_unitOfWork.BusinessKeyword.Update(businessProfileVM.BusinessKeyword);
                    //var businessserviceslist =await _unitOfWork.BusinessService.GetAllAsync(s => s.BusinessId == businessId); 
                    //await _unitOfWork.BusinessService.RemoveRangeAsync(businessserviceslist);
                    //var serviceList = (serviceslist.ToString().Split(','));
                    //if (serviceList.Length > 0)
                    //{
                    //    foreach (var item in serviceList)
                    //    {
                    //        if (!string.IsNullOrEmpty(item))
                    //        {
                    //            BusinessService businessService = new BusinessService();
                    //            businessService.BusinessId = businessId;
                    //            businessService.ServicesId = Convert.ToInt32(item);
                    //            await _unitOfWork.BusinessService.AddAsync(businessService);
                    //        }
                    //    }
                    //}
                    //var businesspaymodelist = await _unitOfWork.BusinessPaymentMode.GetAllAsync(s => s.BusinessId == businessId);
                    //await _unitOfWork.BusinessPaymentMode.RemoveRangeAsync(businesspaymodelist);
                    //var paymentModeList = paymenmodeslist.ToString().Split(',');
                    //if (paymentModeList.Length > 0)
                    //{
                    //    foreach (var item in paymentModeList)
                    //    {
                    //        if (!string.IsNullOrEmpty(item))
                    //        {
                    //            BusinessPaymentMode businessPaymentMode = new BusinessPaymentMode();
                    //            businessPaymentMode.BusinessId = businessId;
                    //            businessPaymentMode.PaymentModeId = Convert.ToInt32(item);
                    //            await _unitOfWork.BusinessPaymentMode.AddAsync(businessPaymentMode);
                    //        }
                    //    }
                    //}
                    _unitOfWork.Save();
                    return LocalRedirect("/Customer/AddressTables/Index?businessid=" + businessId + "&catogory=" + category);
                }
            }
            return RedirectToAction(nameof(MyListing));
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var objFromDb = await _unitOfWork.BusinessCertification.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting Business Type";
                return Json(new { success = false, message = "Error while deleting" });
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.Certificate.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            await _unitOfWork.BusinessCertification.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Business certificate successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImages(int id)
        {
            var objFromDb = await _unitOfWork.BusinessImage.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting Business Type";
                return Json(new { success = false, message = "Error while deleting" });
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            await _unitOfWork.BusinessImage.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Business image successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });
        }

        public IActionResult MyListing()
        {
            return View();
        }

        public async Task<IActionResult> GetMylisting()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var allUserListing =await _unitOfWork.Business.GetAllAsync(s => s.UserId == claim.Value,s=>s.OrderByDescending(x=>x.CreatedOn));
            return Json(new { data = allUserListing });
        }
        public async Task<IActionResult> Detail(int Id)
        {
            BusinessProfileVM businessProfileVM = new BusinessProfileVM()
            {
                Business = await _unitOfWork.Business.GetFirstOrDefaultAsync(s => s.Id == Id,includeProperties: "ApplicationUser"),
                BusinessHour = await _unitOfWork.BusinessHour.GetFirstOrDefaultAsync(s => s.BusinessId == Id),
                BusinessCertification = await _unitOfWork.BusinessCertification.GetAllAsync(s => s.BusinessId == Id),
                BusinessServices = await _unitOfWork.BusinessService.GetAllAsync(s => s.BusinessId == Id),
                BusinessImage = await _unitOfWork.BusinessImage.GetAllAsync(s => s.BusinessId == Id),
                BusinessKeyword = await _unitOfWork.BusinessKeyword.GetFirstOrDefaultAsync(s => s.BusinessId == Id),
                BusinessPaymentModes = await _unitOfWork.BusinessPaymentMode.GetAllAsync(s => s.BusinessId == Id)
            };
            return View(businessProfileVM);
        }
        public IActionResult Favourite()
        {
            return View();
        }

        public async Task<IActionResult> GetFavourite()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var allFavObj = await _unitOfWork.Favourite.GetAllAsync(s => s.UserId == claim.Value, includeProperties: "Company");
            return Json(new { data = allFavObj });
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFavourite(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var objFromDb = await _unitOfWork.Favourite.GetFirstOrDefaultAsync(s => s.UserId == claim.Value && s.BusinessId == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _unitOfWork.Favourite.RemoveAsync(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Remove Successful" });

        }

       

        public async Task<IActionResult> Index()
        {
            IEnumerable<Business> companyList = await _unitOfWork.Business.GetAllAsync(includeProperties: "Category,CoverType");
           
            return View(companyList);
        }
        public async Task<IActionResult> GoToAction(string category, int? businessId)
        {
            return LocalRedirect("/Customer/"+category+"/Upsert?Id=" + businessId);
        }
    }
}
