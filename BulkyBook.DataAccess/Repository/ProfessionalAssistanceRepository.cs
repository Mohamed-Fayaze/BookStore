using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ProfessionalAssistanceRepository : RepositoryAsync<ProfessionalAssistance>, IProfessionalAssistanceRepository
    {
        private readonly ApplicationDbContext _db;

        public ProfessionalAssistanceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProfessionalAssistance professionalAssistance)
        {

            var objFromDb = _db.ProfessionalAssistances.FirstOrDefault(s => s.Id == professionalAssistance.Id);
            if (objFromDb != null)
            {
                objFromDb.Modeofservice = professionalAssistance.Modeofservice;
                objFromDb.OnlineBooking = professionalAssistance.OnlineBooking;
                objFromDb.ServiceType = professionalAssistance.ServiceType;
                
            };
        }
    }
}
