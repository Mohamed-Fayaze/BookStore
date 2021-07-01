using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class HealthcareBranchRepository : RepositoryAsync<HealthcareBranch>, IHealthcareBranchRepository
    {
        private readonly ApplicationDbContext _db;
        public HealthcareBranchRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }
        public void Update(HealthcareBranch healthcareBranch)
        {
            var objFromDb = _db.HealthcareBranch.FirstOrDefault(s => s.Id == healthcareBranch.Id);
            if (objFromDb != null)
            {
                objFromDb.HealthcareId = healthcareBranch.HealthcareId;
                objFromDb.HospitalTypeId = healthcareBranch.HospitalTypeId;
                objFromDb.TestingLabTypeId = healthcareBranch.TestingLabTypeId;
                objFromDb.NursingTypeId = healthcareBranch.NursingTypeId;
                objFromDb.AmbulatoryTypeId = healthcareBranch.AmbulatoryTypeId;
                objFromDb.MedicalSuppliesTypeId = healthcareBranch.MedicalSuppliesTypeId;
                objFromDb.MedicalInsuranceTypeId = healthcareBranch.MedicalInsuranceTypeId;
                objFromDb.PharmaceuticalTypeId = healthcareBranch.PharmaceuticalTypeId;
                objFromDb.DepartmentId = healthcareBranch.DepartmentId;
                objFromDb.FacilityId = healthcareBranch.FacilityId;
                objFromDb.ContactPersonName = healthcareBranch.ContactPersonName;
                objFromDb.ContactNo1 = healthcareBranch.ContactNo1;
                objFromDb.ContactNo2 = healthcareBranch.ContactNo2;
                objFromDb.EmergencyContactNo = healthcareBranch.EmergencyContactNo;
                objFromDb.SocialMediaName = healthcareBranch.SocialMediaName;
                objFromDb.SocialMediaURL = healthcareBranch.SocialMediaURL;
                objFromDb.Address = healthcareBranch.Address;
                objFromDb.State= healthcareBranch.State;
                objFromDb.District= healthcareBranch.District;
                objFromDb.UploadImage = healthcareBranch.UploadImage;
            };
        }
    }
}