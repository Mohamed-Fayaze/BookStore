using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class HealthcareDoctorRepository : RepositoryAsync<HealthcareDoctor>, IHealthcareDoctorRepository
    {
        private readonly ApplicationDbContext _db;
        public HealthcareDoctorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(HealthcareDoctor healthcareDoctor)
        {
            var objFromDb = _db.HealthcareDoctor.FirstOrDefault(s => s.Id == healthcareDoctor.Id);
            if (objFromDb != null)
            {
                objFromDb.BranchId = healthcareDoctor.BranchId;
                objFromDb.DoctorTypeId = healthcareDoctor.DoctorTypeId;
                objFromDb.SpecialityId = healthcareDoctor.SpecialityId;
                objFromDb.QualificationId = healthcareDoctor.QualificationId;
                objFromDb.Experience = healthcareDoctor.Experience;
                objFromDb.NationalityId = healthcareDoctor.NationalityId;
                objFromDb.gender = healthcareDoctor.gender;
                objFromDb.SundayFrom = healthcareDoctor.SundayFrom;
                objFromDb.SundayTo = healthcareDoctor.SundayTo;
                objFromDb.MondayFrom = healthcareDoctor.MondayFrom;
                objFromDb.MondayTo = healthcareDoctor.MondayTo;
                objFromDb.TuesdayFrom = healthcareDoctor.TuesdayFrom;
                objFromDb.TuesdayTo = healthcareDoctor.TuesdayTo;
                objFromDb.WednesdayFrom = healthcareDoctor.WednesdayFrom;
                objFromDb.WednesdayTo = healthcareDoctor.WednesdayTo;
                objFromDb.ThrusdayFrom = healthcareDoctor.ThrusdayFrom;
                objFromDb.ThrusdayTo = healthcareDoctor.ThrusdayTo;
                objFromDb.FridayFrom = healthcareDoctor.FridayFrom;
                objFromDb.FridayTo = healthcareDoctor.FridayTo;
                objFromDb.SaturdayFrom = healthcareDoctor.SaturdayFrom;
                objFromDb.SaturdayTo = healthcareDoctor.SaturdayTo;
                objFromDb.DoctorPhoto = healthcareDoctor.DoctorPhoto;

            }
        }
    }
}

