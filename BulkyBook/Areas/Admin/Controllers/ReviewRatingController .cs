using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    
   
    public class ReviewRatingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ReviewRatingController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(int businessId, int sort = 0, int ReviewPage = 1, string surlid = "")
        {
            ReviewRatingVM reviewRatingVM = new ReviewRatingVM();
            // reviewRatingVM.ReviewRatings = _unitOfWork.ReviewRating.GetAll();

            var reviewRatings = _unitOfWork.ReviewRating.GetAll(s => s.BussinessId == businessId, includeProperties: "ApplicationUser");

            if (sort == 0)
            {
                reviewRatingVM.ReviewRatings = reviewRatings.OrderByDescending(x => x.ReviewOn).Skip((ReviewPage - 1) * 10).Take(10).ToList();
            }
            else if (sort == 1)
            {
                reviewRatingVM.ReviewRatings = reviewRatings.OrderByDescending(y => y.HelpfulCount).Skip((ReviewPage - 1) * 10).Take(10).ToList();
            }

            //reviewRatings = _unitOfWork.ReviewRating.GetAll(null, s => s.OrderBy(x => x.HelpfulCount));
            reviewRatingVM.ReviewRating = new ReviewRating();
            reviewRatingVM.ReviewRating.BussinessId = businessId;
            var count = reviewRatings.Count();
            ViewBag.totalcount = reviewRatingVM.ReviewRatings.Count();
            ViewBag.AverageRating = _unitOfWork.ReviewRating.GetAverageRating(businessId);
            ViewBag.ServiceCount = reviewRatingVM.ReviewRatings.ToList().Where(x => x.Service != null).Count();
            ViewBag.ValueForMoneyCount = reviewRatingVM.ReviewRatings.ToList().Where(x => x.Valueformoney != null).Count();
            reviewRatingVM.PagingInfo = new PagingInfo
            {
                CurrentPage = ReviewPage,
                ItemsPerPage = 10,
                TotalItem = count,
                urlParam = "/Admin/ReviewRating/Index?ReviewPage=:"
            };
            if (string.IsNullOrEmpty(surlid))
            {
                return View(nameof(Index), reviewRatingVM);
            }
            else
            {
                return LocalRedirect(surlid);
            }
        }

        public IActionResult Detail()
        {
            return View();
        }[Authorize]
        public IActionResult ReportAbuse(int id, string surlid)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ReportAbuse rep = new ReportAbuse();
            rep.ReviewRatingId = id;
            rep.UserId = claim.Value;
            //_unitOfWork.ReportAbuse.Add(rep);
            if (!_unitOfWork.ReviewRating.ValidateReportAbuse(rep.UserId, rep.ReviewRatingId))
            {
                _unitOfWork.ReportAbuse.Add(rep);
                TempData["Success"] = "Thank You for your Feedback.";
            }
            ReviewRating reviewRating = _unitOfWork.ReviewRating.Get(id);
            _unitOfWork.Save();
            if (string.IsNullOrEmpty(surlid))
            {
                return Index(businessId: reviewRating.BussinessId.GetValueOrDefault());
            }
            else
            {
                return LocalRedirect(surlid);
            }
        }
        [Authorize]
        public IActionResult Helpful(int id, string surlid)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Helpful hel = new Helpful();
            hel.ReviewRatingId = id;
            hel.UserId = claim.Value;
            if (!_unitOfWork.ReviewRating.ValidateHelpful(hel.UserId, hel.ReviewRatingId))
            {
                _unitOfWork.Helpful.Add(hel);
                _unitOfWork.Save();
                TempData["Success"] = "Thank You for your Feedback.";
            }

            List<Helpful> helpful;
            helpful = _unitOfWork.Helpful.GetAll(s => s.ReviewRatingId == id).ToList();
            int count = helpful.Count();
            ReviewRating reviewRating = _unitOfWork.ReviewRating.Get(id);
            reviewRating.HelpfulCount = (count == 0 ? 1 : count);
            _unitOfWork.ReviewRating.Update(reviewRating);
            _unitOfWork.Save();
            if (string.IsNullOrEmpty(surlid))
            {
                return Index(businessId: reviewRating.BussinessId.GetValueOrDefault());
            }
            else 
            {
                return LocalRedirect(surlid);
            }
        }
        [Authorize]
        public async Task<IActionResult> Upsert(int businessid,int? id)
        {
            ReviewRatingVM reviewRatingVM = new ReviewRatingVM()
            {
                ReviewRating = new ReviewRating(),
            };
            if (id == null)
            {
                reviewRatingVM.ReviewRating.BussinessId = businessid;
                var business = await _unitOfWork.Business.GetAsync(businessid);
                reviewRatingVM.Other = _unitOfWork.Other.GetFirstOrDefault(s => s.CategoryId == business.CategoryId);
                reviewRatingVM.ReviewRating.OtherId = reviewRatingVM.Other.Id;
                //this is for create
                return View(reviewRatingVM);
            }
            //this is for edit
            reviewRatingVM.ReviewRating = _unitOfWork.ReviewRating.Get(id.GetValueOrDefault());
            if (reviewRatingVM.ReviewRating == null)
            {
                return NotFound();
            }
            reviewRatingVM.Other = _unitOfWork.Other.GetFirstOrDefault(s => s.Id == reviewRatingVM.ReviewRating.OtherId);
            return View(reviewRatingVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ReviewRatingVM reviewRatingVM)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
               
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\Review");
                    var extenstion = Path.GetExtension(files[0].FileName);

                    if (reviewRatingVM.ReviewRating.Image != null)
                    {
                        //this is an edit and we need to remove old image
                        var imagePath = Path.Combine(webRootPath, reviewRatingVM.ReviewRating.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using(var filesStreams = new FileStream(Path.Combine(uploads,fileName+extenstion),FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    reviewRatingVM.ReviewRating.Image = @"\images\Review\" + fileName + extenstion;
                }
                else
                {
                    //update when they do not change the image
                    if(reviewRatingVM.ReviewRating.Id != 0)
                    {
                        ReviewRating objFromDb = _unitOfWork.ReviewRating.Get(reviewRatingVM.ReviewRating.Id);
                        reviewRatingVM.ReviewRating.Image = objFromDb.Image;
                    }
                }


                if (reviewRatingVM.ReviewRating.Id == 0)
                {
                    reviewRatingVM.ReviewRating.UserId = claim.Value;
                    reviewRatingVM.ReviewRating.ReviewOn = DateTime.Now;
                   // reviewRatingVM.ReviewRating.OtherId = reviewRatingVM.Other.Id;
                    //reviewRatingVM.ReviewRating.BussinessId = 21;
                    _unitOfWork.ReviewRating.Add(reviewRatingVM.ReviewRating);

                }
                else
                {
                    _unitOfWork.ReviewRating.Update(reviewRatingVM.ReviewRating);
                }
                _unitOfWork.Save();
                return LocalRedirect("/Customer/Home/DetailLive?Id="+reviewRatingVM.ReviewRating.BussinessId.GetValueOrDefault());
            }
            else
            {
                //reviewRatingVM.OtherList = _unitOfWork.Other.GetAll().Select(i => new SelectListItem
                //{
                //    Text = i.Name,
                //    Value = i.Id.ToString()
                //});

                if (reviewRatingVM.ReviewRating.Id != 0)
                {
                    reviewRatingVM.ReviewRating = _unitOfWork.ReviewRating.Get(reviewRatingVM.ReviewRating.Id);
                }
            }
            return View(reviewRatingVM);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.ReviewRating.GetAll(includeProperties:"Other");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.ReviewRating.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            if (objFromDb.Image != null)
            {
                var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            _unitOfWork.ReviewRating.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}