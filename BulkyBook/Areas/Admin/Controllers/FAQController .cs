using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FAQController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FAQController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int businessId, string busUserId, string search, int faqPage = 1)
        {
            ViewData["searchval"]= search;
            FAQVM faqVM = new FAQVM();

            IEnumerable<FAQ> faqlist = _unitOfWork.FAQ.GetAll(s => s.BussinessId == businessId,includeProperties: "ApplicationUser");
            
            if (!string.IsNullOrEmpty(search))
            {
                faqlist = faqlist.Where(x => x.FAQQuestion.Contains(search));
            }
            faqVM.FAQs = faqlist.Skip((faqPage - 1) * 10).Take(10).ToList();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ViewData["userId"] = (claim == null ? "" : claim.Value);
            ViewData["busUserId"] = busUserId;
            faqVM.FAQ = new FAQ();
            faqVM.FAQ.BussinessId = businessId;
            faqVM.FAQ.Company = new Business();
            faqVM.FAQ.Company.UserId = busUserId;
            var count = faqlist.Count();
            faqVM.PagingInfo = new PagingInfo
            {
                CurrentPage = faqPage,
                ItemsPerPage = 10,
                TotalItem = count,
                urlParam = "/Admin/FAQ/Index?faqPage=:"
            };
            return View(nameof(Index), faqVM);
        }
        [Authorize]
        public IActionResult FAQReportAbuse(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            FAQReportAbuse rep = new FAQReportAbuse();
            rep.FAQId= id;
            rep.UserId = claim.Value;
            //_unitOfWork.FAQReportAbuse.Add(rep);
            if (!_unitOfWork.FAQ.ValidateFAQReportAbuse(rep.UserId, rep.FAQId))
            {
                _unitOfWork.FAQReportAbuse.Add(rep);
                TempData["Success"] = "Thank You for your Feedback.";
            }
            FAQ fAQ = _unitOfWork.FAQ.GetFirstOrDefault(s => s.Id == id, includeProperties: "Company");
            _unitOfWork.Save();
            return Index(businessId: fAQ.BussinessId.GetValueOrDefault(), busUserId: fAQ.Company.UserId, search: "");

        }
        [Authorize]
        public IActionResult FAQHelpful(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            FAQHelpful hel = new FAQHelpful();
            hel.FAQId = id;
            hel.UserId = claim.Value;
            //_unitOfWork.FAQHelpful.Add(hel);
            if (!_unitOfWork.FAQ.ValidateFAQHelpful(hel.UserId, hel.FAQId))
            {
                _unitOfWork.FAQHelpful.Add(hel);
                _unitOfWork.Save();
                TempData["Success"] = "Thank You for your Feedback.";
            }
            List<FAQHelpful> helpful;
            helpful = _unitOfWork.FAQHelpful.GetAll(s => s.FAQId == id).ToList();
            int count = helpful.Count();
            FAQ fAQ = _unitOfWork.FAQ.GetFirstOrDefault(s => s.Id == id, includeProperties: "Company"); 
            fAQ.FAQHelpfulCount = count;
            _unitOfWork.FAQ.Update(fAQ);
            _unitOfWork.Save();

            return Index(businessId: fAQ.BussinessId.GetValueOrDefault(), busUserId: fAQ.Company.UserId, search: "");
        }
        public IActionResult Question(int businessid)
        {
            FAQVM faqVM = new FAQVM();
            faqVM.FAQs = _unitOfWork.FAQ.GetAll(s=> s.BussinessId == businessid && s.FAQAnswer == null);
            return View(faqVM);
        }

        [Authorize]
        public IActionResult Upsert(int businessid,int? id)
        {
            FAQVM faqVM = new FAQVM();

            
            if (id == null)
            {
                FAQ faq = new FAQ();

                faqVM.FAQ = faq;
                faqVM.FAQ.BussinessId = businessid;
                //this is for create
                return View(faqVM);
            }
            //this is for edit
            faqVM.FAQ= _unitOfWork.FAQ.Get(id.GetValueOrDefault());
            if (faqVM.FAQ == null)
            {
                return NotFound();
            }
            return View(faqVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FAQVM faqVM)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (faqVM.FAQ.Id == 0)
                {
                    faqVM.FAQ.UserId = claim.Value;
                    faqVM.FAQ.QuestionOn = DateTime.Now;
                    _unitOfWork.FAQ.Add(faqVM.FAQ);

                }
                else
                {
                    faqVM.FAQ.AnswerOn = DateTime.Now;
                    _unitOfWork.FAQ.Update(faqVM.FAQ);
                }
                _unitOfWork.Save();
                FAQ fAQ = _unitOfWork.FAQ.GetFirstOrDefault(s => s.Id == faqVM.FAQ.Id, includeProperties: "Company");
                return Index(businessId:faqVM.FAQ.BussinessId.GetValueOrDefault(), busUserId:fAQ.Company.UserId,search:"");
            }
            else { 

                if (faqVM.FAQ.Id !=0)
                {
                    faqVM.FAQ = _unitOfWork.FAQ.Get(faqVM.FAQ.Id);
                }
            }
            return View(faqVM);
        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.FAQ.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.FAQ.GetFirstOrDefault(s => s.Id == id, includeProperties: "Company");
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.FAQ.Remove(objFromDb);
            _unitOfWork.Save();
            Index(businessId: objFromDb.BussinessId.GetValueOrDefault(), busUserId: objFromDb.Company.UserId, search: "");
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}