using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using BulkyBook.Utility;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HealthcareDoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        
        private static string message;
        public HealthcareDoctorController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var doctortype = await _unitOfWork.Speciality.GetAllAsync(s => s.SpecialityName.Contains(term));
                var name = doctortype.Select(s => s.SpecialityName);
                return Ok(name);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> Listing(Filter filter, int ListingPage = 1)
        {
            HealthcareListVM healthcareListVM = new HealthcareListVM()
            {
                CategoryList = await _unitOfWork.Category.GetAllAsync(),
                SpecialityList = await _unitOfWork.Speciality.GetAllAsync(),
                NationalityList = await _unitOfWork.Nationality.GetAllAsync(),
                LanguageList = await _unitOfWork.Language.GetAllAsync(),
                GenderList = GetGenderList(),
                QualificationList =await _unitOfWork.Qualification.GetAllAsync(),
                StateList = await _unitOfWork.State.GetAllAsync()
            };
            ViewData["nationality"] = HttpContext.Request.Query["filter.Nationality"].ToString();
            ViewData["speciality"] = HttpContext.Request.Query["filter.Speciality"].ToString();
            ViewData["language"]= HttpContext.Request.Query["filter.Language"].ToString();
            ViewData["gender"] = HttpContext.Request.Query["filter.Gender"].ToString();

            if(ViewData["nationality"].ToString() != "") { filter.Nationality = ViewData["nationality"].ToString(); }
            if(ViewData["speciality"].ToString() != "") { filter.Speciality = ViewData["speciality"].ToString(); }
            if(ViewData["language"].ToString() != "") { filter.Language = ViewData["language"].ToString(); }
            if(ViewData["gender"].ToString() != "") { filter.Gender = ViewData["gender"].ToString(); }

            var parameter = new DynamicParameters();
            parameter.Add("@Nationality", filter.Nationality);
            parameter.Add("@Speciality", filter.Speciality);
            parameter.Add("@Language", filter.Language);
            parameter.Add("@Gender", filter.Gender);
            parameter.Add("@State", filter.StateId);
            parameter.Add("@District", filter.District);
            var DoctorList = _unitOfWork.SP_Call.List<DoctorVM>(SD.Proc_HealthcareDoctor_SearchDoctor, parameter);

            //var DoctorList = await _unitOfWork.HealthcareDoctor.GetAllAsync(includeProperties: "HealthcareBranch");
            //if (filter.Nationality != null)
            //{
            //    ViewData["filter.Nationality"] = filter.Nationality;
            //    DoctorList = DoctorList.Where(s => s.NationalityId == filter.Nationality);
            //}
            //if (filter.Speciality != null)
            //{
            //    ViewData["speciality"] = filter.Speciality;
            //    DoctorList = DoctorList.Where(s => s.SpecialityId == filter.Speciality);
            //}
            //if (filter.Nationality != null)
            //{
            //    ViewData["nationality"] = filter.Nationality;
            //    DoctorList = DoctorList.Where(s => s.NationalityId == filter.Nationality);
            //}
            //if (filter.StateId != null)
            //{
            //    ViewData["state"] = filter.StateId;
            //    DoctorList = DoctorList.Where(s => s.HealthcareBranch.StateId == filter.StateId);
            //}
            //else if (filter.State != null)
            //{
            //    var State = await _unitOfWork.State.GetFirstOrDefaultAsync(s => s.Name.Contains(filter.State));
            //    ViewData["state"] = State.Id;
            //    DoctorList = DoctorList.Where(s => s.HealthcareBranch.StateId == State.Id);
            //}
            //if (filter.District != null)
            //{
            //    ViewData["district"] = filter.District;
            //    DoctorList = DoctorList.Where(s => s.HealthcareBranch.DistrictId == filter.District);
            //}
            //if (filter.Gender != null)
            //{
            //    ViewData["gender"] = filter.Gender;
            //    DoctorList = DoctorList.Where(s => s.gender == filter.Gender);
            //}
            //if (filter.Language != null)
            //{
            //    ViewData["language"] = filter.Language;
            //    var language = await _unitOfWork.DoctorLanguage.GetAllAsync(s => s.LanguageId == filter.Language.GetValueOrDefault(), includeProperties: "HealthcareDoctor");
            //    if (language.Count() > 0)
            //    {
            //        DoctorList = language.Select(s => s.HealthcareDoctor).Intersect(DoctorList);
            //    }
            //    else
            //    {
            //        DoctorList = Enumerable.Empty<HealthcareDoctor>();
            //    }
            //}

            var count = DoctorList.Count();
            healthcareListVM.HealthcareDoctors = DoctorList.OrderByDescending(p => p.Id)
                .Skip((ListingPage - 1) * 15).Take(15).ToList();
            healthcareListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = ListingPage,
                ItemsPerPage = 15,
                TotalItem = count,
                urlParam = "/Customer/HealthcareDoctor/Listing?ListingPage=:"
            };
            return View(healthcareListVM);
        }
        public async Task<IActionResult> Index(int BranchId)
        {
            ViewData["branchId"] = BranchId;
            IEnumerable<HealthcareDoctor> healthcareDoctors = await _unitOfWork.HealthcareDoctor.GetAllAsync(s => s.BranchId == BranchId);
            var branch = await _unitOfWork.HealthcareBranch.GetFirstOrDefaultAsync(s => s.Id == BranchId);
            ViewData["healthcareId"] = branch.HealthcareId;
            return View(healthcareDoctors);
        }
        public async Task<IActionResult> Detail(int Id)
        {

            var languages = await _unitOfWork.Language.GetAllAsync();
            HealthcareDoctorVM healthcareDoctorVM = new HealthcareDoctorVM()
            {
                healthcareDoctor = await _unitOfWork.HealthcareDoctor.GetFirstOrDefaultAsync(s => s.Id == Id, includeProperties: "Speciality,Nationality,HealthcareBranch"),
                doctorLanguages = await _unitOfWork.DoctorLanguage.GetAllAsync(s => s.DoctorId == Id),
                LanguageList = languages.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            var hospital = await _unitOfWork.HealthCare.GetFirstOrDefaultAsync(s => s.Id == healthcareDoctorVM.healthcareDoctor.HealthcareBranch.HealthcareId);
            ViewData["Hospital"] = hospital.Name;
            var count = await _unitOfWork.Count.GetFirstOrDefaultAsync(s=>s.DoctorId == Id);
            if (count != null)
            {
                count.viewcount += 1;
                _unitOfWork.Count.Update(count);
            }
            else
            {
                var newcount = new Count()
                {
                    DoctorId = Id,
                    viewcount = 1
                };
                await _unitOfWork.Count.AddAsync(newcount);
            }
            _unitOfWork.Save();
            ViewData["viewcount"] = (count != null ? count.viewcount : 1);
            return View(healthcareDoctorVM);
        }
        [Authorize]
        public async Task<IActionResult> Upsert(int? Id, int BranchId)
        {
            var employeetypes = await _unitOfWork.EmployeeType.GetAllAsync();
            var specialitylist = await _unitOfWork.Speciality.GetAllAsync();
            var qualificationlist = await _unitOfWork.Qualification.GetAllAsync();
            var nationalitylist = await _unitOfWork.Nationality.GetAllAsync();
            var languages = await _unitOfWork.Language.GetAllAsync();
            var Qualification = await _unitOfWork.Qualification.GetAllAsync();
            HealthcareDoctorVM healthcareDoctorVM = new HealthcareDoctorVM()
            {
                healthcareDoctor = new HealthcareDoctor(),
                EmployeeTypes = employeetypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                SpecialityList = specialitylist.Select(i => new SelectListItem
                {
                    Text = i.SpecialityName,
                    Value = i.Id.ToString()
                }),
                QualificationList = qualificationlist.Select(i => new SelectListItem
                {
                    Text = i.Description,
                    Value = i.Id.ToString()
                }),
                NationalityList = nationalitylist.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                LanguageList = languages.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                GenderList = GetGenderList(),
            };

            if (Id == null)
            {
                healthcareDoctorVM.healthcareDoctor.BranchId = BranchId;
                return View(healthcareDoctorVM);
            }
            healthcareDoctorVM.healthcareDoctor = await _unitOfWork.HealthcareDoctor.GetAsync(Id.GetValueOrDefault());
            if (healthcareDoctorVM.healthcareDoctor == null)
            {
                return NotFound();
            }
            return View(healthcareDoctorVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(HealthcareDoctor healthcareDoctor)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                //files operation
                var files = HttpContext.Request.Form.Files;
                //bool Isprofileupdated = false;
                if (files.Count > 0)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var extension = Path.GetExtension(files[i].FileName);
                        var uploads = string.Empty;
                        switch (files[i].Name)
                        {
                            case "Profile":
                                uploads = Path.Combine(webRootPath, @"images\healthcare\doctor");
                                if (healthcareDoctor.DoctorPhoto != null)
                                {
                                    //this is an edit and we need to remove old image
                                    var imagePath = Path.Combine(webRootPath, healthcareDoctor.DoctorPhoto.TrimStart('\\'));
                                    if (System.IO.File.Exists(imagePath))
                                    {
                                        System.IO.File.Delete(imagePath);
                                    }
                                }
                                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                                {
                                    files[i].CopyTo(filesStreams);
                                }
                                healthcareDoctor.DoctorPhoto = @"\images\healthcare\doctor\" + fileName + extension;
                                //Isprofileupdated = true;
                                break;
                        }
                    }
                }


                if (healthcareDoctor.Id == 0)
                {
                    await _unitOfWork.HealthcareDoctor.AddAsync(healthcareDoctor);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.HealthcareDoctor.Update(healthcareDoctor);
                    var doctorlanguages =await  _unitOfWork.DoctorLanguage.GetAllAsync(s => s.DoctorId == healthcareDoctor.Id);
                    if (doctorlanguages != null)
                    {
                        await _unitOfWork.DoctorLanguage.RemoveRangeAsync(doctorlanguages);
                    }
                }
                if (healthcareDoctor.Languages.Count() > 0)
                {
                    IEnumerable<DoctorLanguage> doctorLanguages = Enumerable.Empty<DoctorLanguage>();
                    foreach (var item in healthcareDoctor.Languages)
                    {
                        DoctorLanguage language = new DoctorLanguage()
                        {
                            DoctorId = healthcareDoctor.Id,
                            LanguageId = item,
                        };
                        doctorLanguages = doctorLanguages.Concat(new[] { language });
                    }
                    await _unitOfWork.DoctorLanguage.AddRangeAsync(doctorLanguages);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index", "HealthcareDoctor", new { BranchId = healthcareDoctor.BranchId });
            }
            return View(healthcareDoctor);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.HealthcareDoctor.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.HealthcareDoctor.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

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
    }
}
