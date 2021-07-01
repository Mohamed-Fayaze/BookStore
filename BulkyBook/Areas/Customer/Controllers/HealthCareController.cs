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
using BulkyBook.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dapper;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Customer")]
    public class HealthCareController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HealthCareController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index(Filter filter, int ListingPage = 1)
        {
            HealthcareListVM healthcareListVM = new HealthcareListVM()
            {
                CategoryList = await _unitOfWork.Category.GetAllAsync(),
                SpecialityList = await _unitOfWork.Speciality.GetAllAsync(),
                FacilityList = await _unitOfWork.Facility.GetAllAsync(),
                DepartmentList = await _unitOfWork.Hospitaldepartment.GetAllAsync(),
                NationalityList = await _unitOfWork.Nationality.GetAllAsync(),
                LanguageList = await _unitOfWork.Language.GetAllAsync(),
                GenderList = GetGenderList(),
                DistrictList = await _unitOfWork.District.GetAllAsync(),
                StateList = await _unitOfWork.State.GetAllAsync()
            };

            ViewData["speciality"] = HttpContext.Request.Query["filter.Speciality"].ToString();
            ViewData["facility"] = HttpContext.Request.Query["filter.Facility"].ToString();
            ViewData["language"] = HttpContext.Request.Query["filter.Language"].ToString();
            ViewData["department"] = filter.Department;
            ViewData["state"] = filter.StateId;
            ViewData["hospitalname"] = filter.HospitalName;
            if (ViewData["speciality"].ToString() != "") { filter.Nationality = ViewData["speciality"].ToString(); }
            if (ViewData["facility"].ToString() != "") { filter.Facility = ViewData["facility"].ToString(); }
            if (ViewData["language"].ToString() != "") { filter.Language = ViewData["language"].ToString(); }
            
            var parameter = new DynamicParameters();
            parameter.Add("@Speciality", filter.Speciality);
            parameter.Add("@Facility", filter.Facility);
            parameter.Add("@Language", filter.Language);
            parameter.Add("@Department", filter.Department);
            parameter.Add("@HospitalName", filter.HospitalName);
            parameter.Add("@District", filter.District);
            parameter.Add("@State", filter.StateId);
            var HealthcareList = _unitOfWork.SP_Call.List<HospitalVM>(SD.Proc_Healthcare_SearchHospital, parameter);
            //var HealthcareList = await _unitOfWork.HealthCare.GetAllAsync(includeProperties: "HealthcareBranch,SubCategory");
            //if (filter.Nationality != null)
            //{
            //    ViewData["filter.Nationality"] = filter.Nationality;
            //    var nationality = await _unitOfWork.HealthcareDoctor.GetAllAsync(s => s.NationalityId == filter.Nationality);
            //    HealthcareList = nationality.Select(s => s.HealthcareBranch.Healthcare).Intersect(HealthcareList);
            //}
            //if (filter.Department != null)
            //{
            //    ViewData["department"] = filter.Department;
            //    var hospital = await _unitOfWork.HealthcareBranch.GetAllAsync(s => s.DepartmentId == filter.Department, includeProperties: "Healthcare");
            //    HealthcareList = hospital.Select(s => s.Healthcare).Intersect(HealthcareList);
            //}
            //if (filter.Speciality != null)
            //{
            //    ViewData["speciality"] = filter.Speciality;
            //    var hospital = await _unitOfWork.HealthcareDoctor.GetAllAsync(s => s.SpecialityId == filter.Speciality, includeProperties: "HealthcareBranch");
            //    HealthcareList = hospital.Select(s => s.HealthcareBranch.Healthcare).Intersect(HealthcareList);
            //}
            //if (filter.Facility != null)
            //{
            //    ViewData["facility"] = filter.Facility;
            //    var facility = await _unitOfWork.HealthcareBranch.GetAllAsync(s => s.FacilityId == filter.Facility);
            //    HealthcareList = facility.Select(s => s.Healthcare).Intersect(HealthcareList);
            //}
            //if (filter.Nationality != null)
            //{
            //    ViewData["nationality"] = filter.Nationality;
            //    var nationality = await _unitOfWork.HealthcareDoctor.GetAllAsync(s => s.NationalityId == filter.Nationality);
            //    HealthcareList = nationality.Select(s => s.HealthcareBranch.Healthcare).Intersect(HealthcareList);
            //}
            //if (filter.Language != null)
            //{
            //    ViewData["language"] = filter.Language;
            //    var language = await _unitOfWork.DoctorLanguage.GetAllAsync(s => s.LanguageId == filter.Language.GetValueOrDefault(),includeProperties: "HealthcareDoctor");
            //    if (language.Count() > 0)
            //    {
            //        HealthcareList = language.Select(s => s.HealthcareDoctor.HealthcareBranch.Healthcare).Intersect(HealthcareList);
            //    }
            //    else
            //    {
            //        HealthcareList = Enumerable.Empty<HealthCare>();
            //    }
            //}
            //if (filter.StateId != null)
            //{
            //    ViewData["state"] = filter.StateId;
            //    var state = await _unitOfWork.HealthcareBranch.GetAllAsync(s => s.StateId == filter.StateId);
            //    HealthcareList = state.Select(s => s.Healthcare).Intersect(HealthcareList);
            //}
            //else if(filter.State != null)
            //{
            //    var State = await _unitOfWork.State.GetFirstOrDefaultAsync(s => s.Name.Contains(filter.State));
            //    ViewData["state"] = State.Id;
            //    var state = await _unitOfWork.HealthcareBranch.GetAllAsync(s => s.StateId == State.Id);
            //    HealthcareList = state.Select(s => s.Healthcare).Intersect(HealthcareList);
            //}
            //if (filter.District != null)
            //{
            //    ViewData["district"] = filter.District;
            //    var district = await _unitOfWork.HealthcareBranch.GetAllAsync(s => s.DistrictId == filter.District);
            //    HealthcareList = district.Select(s => s.Healthcare).Intersect(HealthcareList);
            //}
            //if (filter.Gender != null)
            //{
            //    ViewData["gender"] = filter.Gender;
            //    var gender = await _unitOfWork.HealthcareDoctor.GetAllAsync(s => s.gender == filter.Gender);
            //    HealthcareList = gender.Select(s => s.HealthcareBranch.Healthcare).Intersect(HealthcareList);
            //}
            var count = HealthcareList.Count();
            healthcareListVM.Healthcares = HealthcareList.OrderByDescending(p => p.Id)
                .Skip((ListingPage - 1) * 7).Take(7).ToList();
            healthcareListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = ListingPage,
                ItemsPerPage = 7,
                TotalItem = count,
                urlParam = "/Customer/Healthcare/Index?ListingPage=:"
            };
            return View(healthcareListVM);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            HealthcareVM healthcareVM = new HealthcareVM()
            {
                healthcare = await _unitOfWork.HealthCare.GetFirstOrDefaultAsync(s=>s.Id == Id,includeProperties: "SubCategory"),
                Branches = await _unitOfWork.HealthcareBranch.GetAllAsync(s => s.HealthcareId == Id),
            };
            return View(healthcareVM);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var categorylist = await _unitOfWork.SubCategory.GetAllAsync();
            HealthcareVM healthcareVM = new HealthcareVM()
            {
                healthcare = new HealthCare(),
                CategoryList = categorylist.Select(i => new SelectListItem
                {
                    Text = i.SecondaryName,
                    Value = i.SecondaryId.ToString()
                }),
            };

            if (id == null)
            {
                //this is for create
                return View(healthcareVM);
            }
            //this is for edit
            healthcareVM.healthcare = await _unitOfWork.HealthCare.GetAsync(id.GetValueOrDefault());

            if (healthcareVM.healthcare == null)
            {
                return NotFound();
            }
            return View(healthcareVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(HealthCare healthCare)
        {
            if (ModelState.IsValid)
            {
                if (healthCare.Id == 0)
                {
                    await _unitOfWork.HealthCare.AddAsync(healthCare);
                }
                else
                {
                    _unitOfWork.HealthCare.update(healthCare);
                }
                _unitOfWork.Save();
                return RedirectToAction("Upsert", "HealthcareBranch", new { HealthcareId = healthCare.Id });
            }
            return View(healthCare);
        }
        public static IEnumerable<SelectListItem> GetGenderList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Male", Value = "Male"},
                new SelectListItem{Text = "Female", Value = "Female"},
                new SelectListItem{Text = "Others", Value = "Others"}

            };
            return items;
        }


        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.HealthCare.GetAllAsync(includeProperties: "Category");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.HealthCare.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.HealthCare.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
