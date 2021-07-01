using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Customer.Controllers
{
    public class EventOrganizerFilter : Filter
    {
        public int? SubcategoryId { get; set; }
        public int? SpecialityId { get; set; }
    }
    [Area("Customer")]
    public class EventOrganizerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private static string message;
        public EventOrganizerController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index(string searchstring, string locationstring, int? searchcategoryid, string subcategory, EventOrganizerFilter filter, int businessPage = 1)
        {
            BusinessListVM businessListVM = new BusinessListVM();
            businessListVM.addressTable = await _unitOfWork.Address.GetAllAsync();
            businessListVM.address = new Address();
            businessListVM.mobileTable = await _unitOfWork.Mobile.GetAllAsync();
            businessListVM.CategoryList = await _unitOfWork.Category.GetAllAsync();
            businessListVM.LanguageList = await _unitOfWork.Language.GetAllAsync();
            //businessListVM.PaymentModeList = await _unitOfWork.PaymentMode.GetAllAsync();
            businessListVM.OnlineBooking = Getbool();
            IEnumerable<Business> businesslist = Enumerable.Empty<Business>();
            if (searchcategoryid != null)
            {
                businessListVM.promotionimages = await _unitOfWork.Promotionimage.GetAllAsync(s => s.Promotion.Business.Category.CategoryId == searchcategoryid);
            }
            if (!string.IsNullOrEmpty(locationstring))
            {
                ViewData["location"] = locationstring;
            }
            if (!string.IsNullOrEmpty(searchstring))
            {
                ViewData["search"] = searchstring;
                //businesslist = await searchFilter(searchstring);
            }
            //else
            {
                businesslist = await _unitOfWork.Business.GetAllAsync(s => s.IsVerified == true && s.VerifiedStatus == "Approved", includeProperties: "ApplicationUser,Category,SubCategory");
                if (subcategory != null)
                {
                    ViewData["subcategory"] = subcategory;
                    businesslist = businesslist.Where(s => s.SubCategory.SecondaryName.Contains(subcategory));
                }
                //if (filter.Nationality != null)
                //{
                //    ViewData["filter.Nationality"] = filter.Nationality;
                //    var nationality = await _unitOfWork.BusinessLanguage.GetAllAsync(s => s.NationalityId == filter.Nationality);
                //    businesslist = nationality.Select(s => s.Business).Intersect(businesslist);
                //}
                if (filter.OnlineBooking != null)
                {
                    ViewData["filter.OnlineBooking"] = filter.OnlineBooking;
                    var events = await _unitOfWork.Event.GetAllAsync(s => s.OnlineBooking == filter.OnlineBooking.GetValueOrDefault());
                    businesslist = events.Select(s => s.Business).Intersect(businesslist);
                }
                //if (filter.MinPrice != null)
                //{
                //    var price = await _unitOfWork.Event.GetAllAsync(s => s.Minprice >= filter.MinPrice.GetValueOrDefault());
                //    businesslist = price.Select(s => s.Business).Intersect(businesslist);
                //}
                //if (filter.MaxPrice != null)
                //{
                //    var price = await _unitOfWork.Event.GetAllAsync(s => s.MinPrice <= filter.MaxPrice.GetValueOrDefault());
                //    businesslist = price.Select(s => s.Business).Intersect(businesslist);
                //}
                //if (filter.PaymentMode != null)
                //{
                //    ViewData["filter.PaymentMode"] = filter.PaymentMode;
                //    var paymentmode = await _unitOfWork.BusinessPaymentMode.GetAllAsync(s => s.PaymentMode.Name.Contains(filter.PaymentMode));
                //    businesslist = paymentmode.Select(s => s.Business).Intersect(businesslist);
                //}

                if (!string.IsNullOrEmpty(locationstring))
                {
                    ViewData["location"] = locationstring;
                    var addresslist = await _unitOfWork.Address.GetAllAsync(s => s.CityTown.ToLower().Contains(locationstring.ToLower()), includeProperties: "Business");
                    IQueryable<Business> query = addresslist.Select(s => s.Business).AsQueryable();
                    businesslist = businesslist.Intersect(query.Include(s => s.ApplicationUser));
                }
                if (searchcategoryid != null && searchstring == null)
                {
                    ViewData["category"] = searchcategoryid;
                    businesslist = businesslist.Where(s => s.Category.CategoryId == searchcategoryid);
                }
                if (!string.IsNullOrEmpty(searchstring))
                {
                    ViewData["search"] = searchstring;
                    var businessKeywords = await _unitOfWork.BusinessKeyword.GetAllAsync(s => s.Description.ToLower().Contains(searchstring.ToLower()) || s.Business.Name.ToLower().Contains(searchstring.ToLower()));
                    businesslist = businessKeywords.Select(s => s.Business).Intersect(businesslist);
                }
            }

            businessListVM.BusinessList = businesslist.OrderByDescending(p => p.CreatedOn)
                .Skip((businessPage - 1) * 7).Take(7).ToList();
            var count = businesslist.Count();
            businessListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = businessPage,
                ItemsPerPage = 7,
                TotalItem = count,
                urlParam = "/Customer/Home/Index?businessPage=:"
            };
            return View(businessListVM);
        }
        public async Task<IActionResult> Upsert(int? Id, int categoryid, int subcategoryid)
        {
            IEnumerable<BusinessType> BusinessTypeList = await _unitOfWork.BusinessType.GetAllAsync();
            IEnumerable<Category> PrimaryCategoryList = await _unitOfWork.Category.GetAllAsync();
            IEnumerable<PaymentMode> PaymentModeList = await _unitOfWork.PaymentMode.GetAllAsync();
            IEnumerable<HospitalDepartment> DepartmentList = await _unitOfWork.Hospitaldepartment.GetAllAsync();
            IEnumerable<Speciality> SpecialityList = await _unitOfWork.Speciality.GetAllAsync();


            CategoryVM categoryVM = new CategoryVM()
            {
                Business = new Business(),
                
                BusinessKeyword = new BusinessKeyword(),
                BusinessHour = new BusinessHour(),

                BusinessTypeList = BusinessTypeList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                PrimaryCategoryList = PrimaryCategoryList.Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
                PaymentModeList = PaymentModeList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                DepartmentList = DepartmentList.Select(i => new SelectListItem
                {
                    Text = i.DepartmentName,
                    Value = i.Id.ToString()
                }),
                SpecialityList = SpecialityList.Select(i => new SelectListItem
                {
                    Text = i.SpecialityName,
                    Value = i.Id.ToString()
                }),


            };
            if (Id == null)
            {
                //this is for create
                categoryVM.Business.CategoryId = categoryid;
                categoryVM.Business.SubCategoryId = subcategoryid;
                categoryVM.BusinessImage = Enumerable.Empty<BusinessImage>();
                categoryVM.BusinessPaymentModes = Enumerable.Empty<BusinessPaymentMode>();
                return View(categoryVM);
            }
            //For Edit
            categoryVM.Business = await _unitOfWork.Business.GetFirstOrDefaultAsync(s => s.Id == Id);
            
            categoryVM.BusinessHour = await _unitOfWork.BusinessHour.GetFirstOrDefaultAsync(s => s.BusinessId == Id);
            categoryVM.BusinessPaymentModes = await _unitOfWork.BusinessPaymentMode.GetAllAsync(s => s.BusinessId == Id);
            categoryVM.BusinessImage = await _unitOfWork.BusinessImage.GetAllAsync(s => s.BusinessId == Id);
            categoryVM.BusinessKeyword = await _unitOfWork.BusinessKeyword.GetFirstOrDefaultAsync(s => s.BusinessId == Id);
            return View(categoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CategoryVM categoryVM)
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
                    categoryVM.BusinessImage = Enumerable.Empty<BusinessImage>();
                    for (int i = 0; i < files.Count; i++)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var extension = Path.GetExtension(files[i].FileName);
                        var uploads = string.Empty;

                        switch (files[i].Name)
                        {
                            case "Profile":

                                uploads = Path.Combine(webRootPath, @"images\business\profile");
                                if (categoryVM.Business.ProfilePhoto != null)
                                {
                                    //this is an edit and we need to remove old image
                                    var imagePath = Path.Combine(webRootPath, categoryVM.Business.ProfilePhoto.TrimStart('\\'));
                                    if (System.IO.File.Exists(imagePath))
                                    {
                                        System.IO.File.Delete(imagePath);
                                    }
                                }
                                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                                {
                                    files[i].CopyTo(filesStreams);
                                }
                                categoryVM.Business.ProfilePhoto = @"\images\business\profile\" + fileName + extension;
                                //Isprofileupdated = true;
                                break;

                            case "businessimage":

                                BusinessImage businessImage = new BusinessImage();
                                uploads = Path.Combine(webRootPath, @"images\business\image");
                                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                                {
                                    files[i].CopyTo(filesStreams);
                                }
                                businessImage.Image = @"\images\business\image\" + fileName + extension;
                                categoryVM.BusinessImage = categoryVM.BusinessImage.Concat(new[] { businessImage });
                                break;
                        }
                    }
                }
                //Data operation
                var serviceslist = HttpContext.Request.Form["service"];
                var paymenmodeslist = HttpContext.Request.Form["paymentMode"];
                if (categoryVM.HealthCare.Id == 0)
                {
                    //var categoryid = 0;
                    //var subcategoryid = 0;
                    //var category = await _unitOfWork.Category.GetFirstOrDefaultAsync(s => s.CategoryName.ToLower().Contains("health care"));
                    //if (category != null)
                    //{
                    //    categoryid = category.CategoryId;
                    //}
                    //var subcategory = await _unitOfWork.SubCategory.GetFirstOrDefaultAsync(s => s.SecondaryName.ToLower().Contains("ambulatory"));
                    //if (subcategory != null)
                    //{
                    //    subcategoryid = subcategory.SecondaryId;
                    //}
                    //categoryVM.Business.CategoryId = categoryid;
                    //categoryVM.Business.SubCategoryId = subcategoryid;
                    //categoryVM.Business.UserId = claim.Value;
                    //categoryVM.Business.CreatedOn = DateTime.Now;
                    //categoryVM.Business.LastOperation = 'I';
                    //categoryVM.Business.LastOperationOn = DateTime.Now;
                    //await _unitOfWork.Business.AddAsync(categoryVM.Business);
                    //var result = _unitOfWork.Save();
                    //if (result)
                    {
                        _unitOfWork.Business.Update(categoryVM.Business);
                        var businessId = categoryVM.Business.Id;
                     
                        await _unitOfWork.HealthCare.AddAsync(categoryVM.HealthCare);
                        if (!string.IsNullOrEmpty(categoryVM.BusinessKeyword.Description))
                        {
                            categoryVM.BusinessKeyword.BusinessId = businessId;
                            await _unitOfWork.BusinessKeyword.AddAsync(categoryVM.BusinessKeyword);
                        }
                        categoryVM.BusinessHour.BusinessId = businessId;
                        await _unitOfWork.BusinessHour.AddAsync(categoryVM.BusinessHour);
                        if (categoryVM.BusinessImage != null)
                        {
                            foreach (var item in categoryVM.BusinessImage)
                            {
                                item.BusinessId = businessId;
                            }
                            if (categoryVM.BusinessImage.Count() > 0)
                            {
                                await _unitOfWork.BusinessImage.AddRangeAsync(categoryVM.BusinessImage);
                            }
                        }

                        var serviceList = (serviceslist.ToString().Split(','));
                        if (serviceList.Length > 0)
                        {
                            foreach (var item in serviceList)
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    BusinessService businessService = new BusinessService();
                                    businessService.BusinessId = businessId;
                                    businessService.ServicesId = Convert.ToInt32(item);
                                    await _unitOfWork.BusinessService.AddAsync(businessService);
                                }
                            }
                        }
                        var paymentModeList = paymenmodeslist.ToString().Split(',');
                        if (paymentModeList.Length > 0)
                        {
                            foreach (var item in paymentModeList)
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    BusinessPaymentMode businessPaymentMode = new BusinessPaymentMode();
                                    businessPaymentMode.BusinessId = businessId;
                                    businessPaymentMode.PaymentModeId = Convert.ToInt32(item);
                                    await _unitOfWork.BusinessPaymentMode.AddAsync(businessPaymentMode);
                                }
                            }
                        }
                        var result = _unitOfWork.Save();
                        //return LocalRedirect("/Customer/AddressTables/Index?businessid=" + businessId);
                        //return LocalRedirect("/Customer/Event/AddressIndex?BusinessId=" + businessId);
                        return RedirectToAction(nameof(AddressIndex), new { BusinessId = businessId });
                    }
                }
                else
                {
                    categoryVM.Business.LastOperation = 'U';
                    categoryVM.Business.LastOperationOn = DateTime.Now;
                    _unitOfWork.Business.Update(categoryVM.Business);
                    _unitOfWork.HealthCare.update(categoryVM.HealthCare);
                    var businessId = categoryVM.Business.Id;
                    if (!string.IsNullOrEmpty(categoryVM.BusinessKeyword.Description))
                    {
                        categoryVM.BusinessKeyword.BusinessId = businessId;
                        await _unitOfWork.BusinessKeyword.AddAsync(categoryVM.BusinessKeyword);
                    }
                    _unitOfWork.BusinessHour.Update(categoryVM.BusinessHour);

                    if (categoryVM.BusinessImage != null)
                    {
                        foreach (var item in categoryVM.BusinessImage)
                        {
                            item.BusinessId = businessId;
                        }
                        if (categoryVM.BusinessImage.Count() > 0)
                        {
                            await _unitOfWork.BusinessImage.AddRangeAsync(categoryVM.BusinessImage);
                        }
                    }
                    _unitOfWork.BusinessKeyword.Update(categoryVM.BusinessKeyword);
                    var businesspaymodelist = await _unitOfWork.BusinessPaymentMode.GetAllAsync(s => s.BusinessId == businessId);
                    await _unitOfWork.BusinessPaymentMode.RemoveRangeAsync(businesspaymodelist);
                    var paymentModeList = paymenmodeslist.ToString().Split(',');
                    if (paymentModeList.Length > 0)
                    {
                        foreach (var item in paymentModeList)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                BusinessPaymentMode businessPaymentMode = new BusinessPaymentMode();
                                businessPaymentMode.BusinessId = businessId;
                                businessPaymentMode.PaymentModeId = Convert.ToInt32(item);
                                await _unitOfWork.BusinessPaymentMode.AddAsync(businessPaymentMode);
                            }
                        }
                    }
                    _unitOfWork.Save();
                }
            }
            return RedirectToAction("MyListing", "BusinessProfile");
        }
        [Authorize]
        public async Task<IActionResult> AddressIndex(int BusinessId)
        {
            var address = await _unitOfWork.Address.GetAllAsync(s => s.BusinessId == BusinessId);
            if (address.Count() == 0)
            {
                //return LocalRedirect("/Customer/Event/AddressUpsert?BusinessId=" + BusinessId);
                return RedirectToAction(nameof(AddressUpsert), new { BusinessId = BusinessId });
            }
            ViewData["businessId"] = BusinessId;
            return View(address);
        }

        [Authorize]
        public async Task<IActionResult> BusinessInfoUpsert(int? Id)
        {
            string category = "Nursing";
            IEnumerable<BusinessType> BusinessTypeList = await _unitOfWork.BusinessType.GetAllAsync();
            ViewData["category"] = category;
            var categoryId = 0;
            var subCategoryId = 0;
            var subcategory = await _unitOfWork.SubCategory.GetFirstOrDefaultAsync(s => s.SecondaryName.Contains(category));
            if (subcategory != null)
            {
                categoryId = subcategory.CategoryId;
                subCategoryId = subcategory.SecondaryId;
            }
            BusinessProfileVM businessProfileVM = new BusinessProfileVM()
            {
                Business = new Business(),
                BusinessTypeList = BusinessTypeList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (Id == null)
            {
                businessProfileVM.Business.CategoryId = categoryId;
                businessProfileVM.Business.SubCategoryId = subCategoryId;
                return View(businessProfileVM);
            }
            //For Edit
            businessProfileVM.Business = await _unitOfWork.Business.GetFirstOrDefaultAsync(s => s.Id == Id);
            return View(businessProfileVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BusinessInfoUpsert(BusinessProfileVM businessProfileVM)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddressAdd", businessProfileVM.Business);
                //return LocalRedirect("/Customer/Hospital/AddressUpsert?business="+ businessProfileVM.Business);
            }
            return View(businessProfileVM);
        }
        [Authorize]
        public IActionResult AddressAdd(Business business)
        {
            List<SelectListItem> addresstype = new List<SelectListItem>();
            addresstype.Add(new SelectListItem() { Text = "Business", Value = "Business" });
            addresstype.Add(new SelectListItem() { Text = "Home", Value = "Home" });
            ViewBag.Addresstype = new SelectList(addresstype, "Value", "Text");
            ContactVM contactVM = new ContactVM()
            {
                addressTable = new Address(),
                Business = business,
                MobileTable = Enumerable.Empty<Mobile>().ToList(),
                LandlineTable = Enumerable.Empty<Landline>().ToList(),
                EmailTable = Enumerable.Empty<Email>().ToList(),
                SocialTable = Enumerable.Empty<Social>().ToList(),
                locationTable = new Location()
            };
            //this is for create
            return View("AddressUpsert", contactVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddressUpsert(ContactVM contactVM)
        {
            if (ModelState.IsValid)
            {
                if (contactVM.addressTable.AddressId == 0)
                {
                    var claimsIdentity = (ClaimsIdentity)User.Identity;
                    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                    contactVM.Business.UserId = claim.Value;
                    contactVM.Business.CreatedOn = DateTime.Now;
                    contactVM.Business.LastOperation = 'I';
                    contactVM.Business.LastOperationOn = DateTime.Now;
                    await _unitOfWork.Business.AddAsync(contactVM.Business);
                    _unitOfWork.Save();
                    contactVM.addressTable.BusinessId = contactVM.Business.Id;
                    contactVM.addressTable.UserId = claim.Value;
                    await _unitOfWork.Address.AddAsync(contactVM.addressTable);
                    _unitOfWork.Save();
                    contactVM.locationTable.AddressId = contactVM.addressTable.AddressId;
                    await _unitOfWork.Mobile.UpsertAsync(contactVM.MobileTable, contactVM.addressTable.AddressId);
                    await _unitOfWork.Landline.UpsertAsync(contactVM.LandlineTable, contactVM.addressTable.AddressId);
                    await _unitOfWork.Email.UpsertAsync(contactVM.EmailTable, contactVM.addressTable.AddressId);
                    await _unitOfWork.Social.UpsertAsync(contactVM.SocialTable, contactVM.addressTable.AddressId);
                    await _unitOfWork.Location.AddAsync(contactVM.locationTable);
                }
                else
                {
                    _unitOfWork.Address.Update(contactVM.addressTable);
                    await _unitOfWork.Mobile.UpsertAsync(contactVM.MobileTable, contactVM.addressTable.AddressId);
                    await _unitOfWork.Landline.UpsertAsync(contactVM.LandlineTable, contactVM.addressTable.AddressId);
                    await _unitOfWork.Email.UpsertAsync(contactVM.EmailTable, contactVM.addressTable.AddressId);
                    await _unitOfWork.Social.UpsertAsync(contactVM.SocialTable, contactVM.addressTable.AddressId);
                    _unitOfWork.Location.Update(contactVM.locationTable);
                }
                _unitOfWork.Save();
                //return LocalRedirect("/Customer/Hospital/AddressIndex?BusinessId=" + contactVM.Business.Id);
                //return LocalRedirect("/Customer/Event/Upsert?Id=" + contactVM.Business.Id);
                return RedirectToAction(nameof(Upsert), new { Id = contactVM.Business.Id });
            }
            return View(contactVM);
        }
        public static IEnumerable<SelectListItem> Getbool()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
            new SelectListItem{Text = "Yes", Value = "True"},
            new SelectListItem{Text = "No", Value = "False"}
            };
            return items;
        }
    }
}
