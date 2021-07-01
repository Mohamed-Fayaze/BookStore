using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public IActionResult AddListingCategory()
        {
            return View();
        }
        public async Task<IActionResult> SubCategory(string searchstring, string locationstring, int? searchcategoryid)
        {
            ViewData["location"] = locationstring;
            ViewData["search"] = searchstring;
            ViewData["category"] = searchcategoryid;
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.primaries = await _unitOfWork.Category.GetAllAsync();
            return View(categoryVM);
        }
        public async Task<IActionResult> Index(string searchstring, string locationstring, int? searchcategoryid, Filter filter, int businessPage = 1)
        {
            if(searchcategoryid != null)
            {
                var categoryLst = await _unitOfWork.Category.GetFirstOrDefaultAsync(s => s.CategoryId == searchcategoryid && s.CategoryName.Contains("Health"));
                if(categoryLst != null)
                {
                    //return RedirectToAction(nameof(SubCategory));
                    return LocalRedirect("/Customer/Home/SubCategory?searchcategoryid=" + searchcategoryid+ "&locationstring="+locationstring+ "&searchstring="+searchstring);
                }
            }
            //
            BusinessListVM businessListVM = new BusinessListVM();
            businessListVM.addressTable = await _unitOfWork.Address.GetAllAsync();
            businessListVM.address = new Address();
            businessListVM.mobileTable = await _unitOfWork.Mobile.GetAllAsync();
            businessListVM.CategoryList = await _unitOfWork.Category.GetAllAsync();
            businessListVM.DepartmentList = await _unitOfWork.Hospitaldepartment.GetAllAsync();
            businessListVM.SpecialityList = await _unitOfWork.Speciality.GetAllAsync();
            businessListVM.FacilityList = await _unitOfWork.Facility.GetAllAsync();
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
                businesslist = await _unitOfWork.Business.GetAllAsync(s => s.IsVerified == true && s.VerifiedStatus == "Approved", includeProperties: "ApplicationUser,Category");

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
                //if(filter.DepartmentId != null)
                //{
                //    ViewData["department"] = filter.DepartmentId;
                //    var hospital = await _unitOfWork.Hospital.GetAllAsync(s => s.DepartmentId == filter.DepartmentId, includeProperties: "Business");
                //    businesslist = hospital.Select(s => s.Business).Intersect(businesslist);
                //}
                //if (filter.SpecialityId != null)
                //{
                //    ViewData["speciality"] = filter.SpecialityId;
                //    var hospital = await _unitOfWork.Hospital.GetAllAsync(s => s.SpecialityId == filter.SpecialityId, includeProperties: "Business");
                //    businesslist = hospital.Select(s => s.Business).Intersect(businesslist);
                //}
                //if (filter.Facility != null)
                //{
                //    ViewData["facility"] = filter.Facility;
                //    var facility = await _unitOfWork.Facility.GetFirstOrDefaultAsync(s => s.Name == filter.Facility);
                //    if (facility != null)
                //    {
                //        var facilityid = Convert.ToString(facility.Id);
                //        var hospital = await _unitOfWork.Hospital.GetAllAsync(s => s.Facility.ToLower().Contains(facilityid), includeProperties: "Business");
                //        businesslist = hospital.Select(s => s.Business).Intersect(businesslist);
                //    }
                //}
            }

            businessListVM.BusinessList = businesslist.OrderByDescending(p => p.CreatedOn)
                .Skip((businessPage - 1) * 7).Take(7).ToList();
            var count = businessListVM.BusinessList.Count();
            businessListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = businessPage,
                ItemsPerPage = 7,
                TotalItem = count,
                urlParam = "/Customer/Home/Index?businessPage=:"
            };
            return View(businessListVM);
        }
        
        public async Task<IActionResult> DetailLive(int Id, int reviewsort = 0, int ReviewPage = 1)
        {
            BusinessProfileVM businessProfileVM = new BusinessProfileVM()
            {
                Business = await _unitOfWork.Business.GetFirstOrDefaultAsync(s => s.Id == Id, includeProperties: "ApplicationUser"),
                BusinessHour = await _unitOfWork.BusinessHour.GetFirstOrDefaultAsync(s => s.BusinessId == Id),
                BusinessCertification = await _unitOfWork.BusinessCertification.GetAllAsync(s => s.BusinessId == Id),
                BusinessServices = await _unitOfWork.BusinessService.GetAllAsync(s => s.BusinessId == Id, includeProperties: "Services"),
                BusinessImage = await _unitOfWork.BusinessImage.GetAllAsync(s => s.BusinessId == Id),
                BusinessKeyword = await _unitOfWork.BusinessKeyword.GetFirstOrDefaultAsync(s => s.BusinessId == Id),
                BusinessPaymentModes = await _unitOfWork.BusinessPaymentMode.GetAllAsync(s => s.BusinessId == Id, includeProperties: "PaymentMode"),

                addressTable = await _unitOfWork.Address.GetAllAsync(s => s.BusinessId == Id),
                mobileTable = await _unitOfWork.Mobile.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                emailTable = await _unitOfWork.Email.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                landlineTable = await _unitOfWork.Landline.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                locationTable = await _unitOfWork.Location.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                socialTable = await _unitOfWork.Social.GetAllAsync(s => s.Address.BusinessId == Id, includeProperties: "Address"),
                FAQs = _unitOfWork.FAQ.GetAll(s => s.BussinessId == Id, includeProperties: "ApplicationUser").Take(5).ToList(),
            };
            //
            var reviewRatings = _unitOfWork.ReviewRating.GetAll(s => s.BussinessId == Id, includeProperties: "ApplicationUser");
            businessProfileVM.ReviewRatingVM = new ReviewRatingVM();
            if (reviewsort == 0)
            {
                businessProfileVM.ReviewRatingVM.ReviewRatings = reviewRatings.OrderByDescending(x => x.ReviewOn).Skip((ReviewPage - 1) * 5).Take(5).ToList();
            }
            else if (reviewsort == 1)
            {
                businessProfileVM.ReviewRatingVM.ReviewRatings = reviewRatings.OrderByDescending(y => y.HelpfulCount).Skip((ReviewPage - 1) * 5).Take(5).ToList();
            }

            //reviewRatings = _unitOfWork.ReviewRating.GetAll(null, s => s.OrderBy(x => x.HelpfulCount));
            businessProfileVM.address = new Address();
            var count = reviewRatings.Count();
            ViewBag.totalcount = businessProfileVM.ReviewRatingVM.ReviewRatings.Count();
            ViewBag.AverageRating = _unitOfWork.ReviewRating.GetAverageRating(Id);
            ViewBag.ServiceCount = businessProfileVM.ReviewRatingVM.ReviewRatings.ToList().Where(x => x.Service != null).Count();
            ViewBag.ValueForMoneyCount = businessProfileVM.ReviewRatingVM.ReviewRatings.ToList().Where(x => x.Valueformoney != null).Count();
            businessProfileVM.ReviewRatingVM.PagingInfo = new PagingInfo
            {
                CurrentPage = ReviewPage,
                ItemsPerPage = 5,
                TotalItem = count,
                urlParam = "/Admin/ReviewRating/Index?ReviewPage=:"
            };
            //

            //ViewBag.AverageRating = _unitOfWork.GetAverageRating(Id);
            //ViewBag.ServiceCount = businessProfileVM.ReviewRatings.ToList().Where(x => x.Service != null).Count();
            //ViewBag.ValueForMoneyCount = businessProfileVM.ReviewRatings.ToList().Where(x => x.Valueformoney != null).Count();

            return View(businessProfileVM);
        }

        public IActionResult Details(int id)
        {
            var productFromDb = _unitOfWork.Product.
                        GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,CoverType");
            ShoppingCart cartObj = new ShoppingCart()
            {
                Product = productFromDb,
                ProductId = productFromDb.Id
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart CartObject)
        {
            CartObject.Id = 0;
            if (ModelState.IsValid)
            {
                //then we will add to cart
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CartObject.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                    u => u.ApplicationUserId == CartObject.ApplicationUserId && u.ProductId == CartObject.ProductId
                    , includeProperties: "Product"
                    );

                if (cartFromDb == null)
                {
                    //no records exists in database for that product for that user
                    _unitOfWork.ShoppingCart.Add(CartObject);
                }
                else
                {
                    cartFromDb.Count += CartObject.Count;
                    //_unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                _unitOfWork.Save();

                var count = _unitOfWork.ShoppingCart
                    .GetAll(c => c.ApplicationUserId == CartObject.ApplicationUserId)
                    .ToList().Count();

                //HttpContext.Session.SetObject(SD.ssShoppingCart, CartObject);
                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var productFromDb = _unitOfWork.Product.
                        GetFirstOrDefault(u => u.Id == CartObject.ProductId, includeProperties: "Category,CoverType");
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Product = productFromDb,
                    ProductId = productFromDb.Id
                };
                return View(cartObj);
            }


        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult City()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> AddFavourite(int businessid)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Favourite favourite = await _unitOfWork.Favourite.GetFirstOrDefaultAsync(s => s.UserId == claim.Value && s.BusinessId == businessid);
            if (favourite != null)
            {
                await _unitOfWork.Favourite.RemoveAsync(favourite);
            }
            else
            {
                favourite = new Favourite();
                favourite.UserId = claim.Value;
                favourite.BusinessId = businessid;
                await _unitOfWork.Favourite.AddAsync(favourite);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IEnumerable<Business>> searchFilter(string search)
        {
            string[] Searchlist = search.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //IEnumerable<Company> businesslist = Enumerable.Empty<Company>();
            var businesslist = await _unitOfWork.Business.GetAllAsync(s => s.IsVerified == true && s.VerifiedStatus == "Approved", includeProperties: "Category,ApplicationUser");
            businesslist = businesslist.AsQueryable().Include("AspNetUser");
            var count = 0;
            for (int i = 0; i < Searchlist.Length; i++)
            {
                if (Searchlist[i].ToLower() == "in" || Searchlist[i].ToLower() == "near")
                {
                    i++;
                    //location filter
                    if (i < Searchlist.Length)
                    {
                        var addressTables = await _unitOfWork.Address.GetAllAsync(s => s.CityTown.ToLower() == Searchlist[i].ToLower() || s.Landmark.ToLower() == Searchlist[i].ToLower());
                        businesslist = addressTables.Select(s => s.Business).Intersect(businesslist);
                        count++;
                        continue;
                    }
                }
                else
                {
                    //category filter
                    var category = await _unitOfWork.Business.GetAllAsync(s => s.Category.CategoryName.ToLower() == Searchlist[i].ToLower());
                    if (category.Count() > 0)
                    {
                        businesslist = category.Intersect(businesslist);
                        count++;
                        continue;
                    }
                    //subcategory filter
                    var subCategory = await _unitOfWork.SubCategory.GetFirstOrDefaultAsync(s => s.SecondaryName.ToLower() == Searchlist[i].ToLower() || s.PrimaryCategory.CategoryName.ToLower() == Searchlist[i].ToLower());
                    if (subCategory != null)
                    {
                        category = await _unitOfWork.Business.GetAllAsync(s => s.Category.CategoryId == subCategory.PrimaryCategory.CategoryId);
                        if (category.Count() > 0)
                        {
                            businesslist = category.Intersect(businesslist);
                            count++;
                            continue;
                        }
                    }
                    //business filter
                    //var business = await _unitOfWork.Business.GetAllAsync(s => s.Name.ToLower() == Searchlist[i].ToLower());
                    //if (business.Count() > 0)
                    //{
                    //    businesslist = business.Intersect(businesslist);
                    //    count++;
                    //    continue;
                    //}
                    //keyword filter
                    var keywords = await _unitOfWork.BusinessKeyword.GetAllAsync(s => s.Description.ToLower().Contains(Searchlist[i].ToLower()) || s.Business.Name.ToLower().Contains(Searchlist[i].ToLower()));
                    if (keywords.Count() > 0)
                    {
                        businesslist = keywords.Select(s => s.Business).Intersect(businesslist);
                        count++;
                        continue;
                    }
                }
            }
            if (count == 0)
            {
                return businesslist = Enumerable.Empty<Business>();
            }
            return businesslist;
        }
    }
}
