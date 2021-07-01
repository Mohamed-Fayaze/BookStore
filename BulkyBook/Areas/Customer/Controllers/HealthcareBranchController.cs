using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BulkyBook.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HealthcareBranchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private static string message;
        public HealthcareBranchController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index(int HealthcareId)
        {
            ViewData["healthcareId"] = HealthcareId;
            IEnumerable<HealthcareBranch> healthcareBranches = await _unitOfWork.HealthcareBranch.GetAllAsync(s => s.HealthcareId == HealthcareId, includeProperties: "HospitalType,Department,Facility");
            return View(healthcareBranches);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            HealthcareBranchVM healthcareBranchVM = new HealthcareBranchVM()
            {
                HealthcareBranch = await _unitOfWork.HealthcareBranch.GetFirstOrDefaultAsync(s => s.Id == Id, includeProperties: "HospitalType,Department,Facility"),
                HealthcareDoctors = await _unitOfWork.HealthcareDoctor.GetAllAsync(s => s.BranchId == Id,includeProperties: "Speciality,Nationality")
            };
            return View(healthcareBranchVM);
        }
        [Authorize]
        public async Task<IActionResult> Upsert(int? Id, int? HealthcareId)
        {
            var healthcare =await _unitOfWork.HealthCare.GetFirstOrDefaultAsync(s => s.Id == HealthcareId,includeProperties:"SubCategory");
            if (healthcare != null)
            {
                var subcategory = healthcare.SubCategory.SecondaryName.ToLower().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (subcategory[0] == "medical")
                {
                    ViewData["subcategory"] = subcategory[1];
                }
                else
                {
                    ViewData["subcategory"] = subcategory[0];
                }
            }
            IEnumerable<HospitalType> HospitalTypes = await _unitOfWork.HospitalType.GetAllAsync();
            IEnumerable<NursingType> NursingTypes = await _unitOfWork.NursingType.GetAllAsync();
            IEnumerable<TestingLabType> TestingLabTypes = await _unitOfWork.TestingLabType.GetAllAsync();
            IEnumerable<AmbulatoryType> AmbulatoryTypes = await _unitOfWork.AmbulatoryType.GetAllAsync();
            IEnumerable<MedicalInsuranceType> MedicalInsuranceTypes = await _unitOfWork.MedicalInsuranceType.GetAllAsync();
            IEnumerable<MedicalSuppliesType> MedicalSuppliesTypes = await _unitOfWork.MedicalSuppliesType.GetAllAsync();
            IEnumerable<PharmaceuticalType> PharmaceuticalTypes = await _unitOfWork.PharmaceuticalType.GetAllAsync();
            IEnumerable<HospitalDepartment> Departments = await _unitOfWork.Hospitaldepartment.GetAllAsync();
            IEnumerable<Facility> Facility = await _unitOfWork.Facility.GetAllAsync();
            IEnumerable<State> State = await _unitOfWork.State.GetAllAsync();
            IEnumerable<District> District = await _unitOfWork.District.GetAllAsync();
            HealthcareBranchVM healthcareBranchVM = new HealthcareBranchVM()
            {
                HealthcareBranch = new HealthcareBranch(),
                HospitalTypeList = HospitalTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                NursingTypeList = NursingTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                TestingLabTypeList = TestingLabTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                AmbulatoryTypeList = AmbulatoryTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                MedicalInsuranceTypeList = MedicalInsuranceTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                MedicalSuppliesTypeList = MedicalSuppliesTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                PharmaceuticalTypeList = PharmaceuticalTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                DepartmentList = Departments.Select(i => new SelectListItem
                {
                    Text = i.DepartmentName,
                    Value = i.Id.ToString()
                }),
                FacilityList = Facility.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                StateList = State.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                DistrictList = District.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (Id == null)
            {
                healthcareBranchVM.HealthcareBranch.HealthcareId = HealthcareId.GetValueOrDefault();
                return View(healthcareBranchVM);
            }
            var branch = await _unitOfWork.HealthcareBranch.GetAsync(Id.GetValueOrDefault());
            if (branch == null)
            {
                return NotFound();
            }
            healthcareBranchVM.HealthcareBranch = branch;
            healthcareBranchVM.HealthcareDoctors = await _unitOfWork.HealthcareDoctor.GetAllAsync(s => s.BranchId == Id.GetValueOrDefault());
            return View(healthcareBranchVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(HealthcareBranch healthcareBranch)
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
                                uploads = Path.Combine(webRootPath, @"images\healthcare\branch");
                                if (healthcareBranch.UploadImage != null)
                                {
                                    //this is an edit and we need to remove old image
                                    var imagePath = Path.Combine(webRootPath, healthcareBranch.UploadImage.TrimStart('\\'));
                                    if (System.IO.File.Exists(imagePath))
                                    {
                                        System.IO.File.Delete(imagePath);
                                    }
                                }
                                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                                {
                                    files[i].CopyTo(filesStreams);
                                }
                                healthcareBranch.UploadImage = @"\images\healthcare\branch\" + fileName + extension;
                                //Isprofileupdated = true;
                                break;
                        }
                    }
                }
                if (healthcareBranch.Id == 0)
                {
                    await _unitOfWork.HealthcareBranch.AddAsync(healthcareBranch);
                }
                else
                {
                    _unitOfWork.HealthcareBranch.Update(healthcareBranch);
                }
                _unitOfWork.Save();
                return RedirectToAction("Upsert", "HealthcareDoctor", new { BranchId = healthcareBranch.Id });
            }
            return View(healthcareBranch);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.HealthcareBranch.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.HealthcareBranch.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = " successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }
    }
}
