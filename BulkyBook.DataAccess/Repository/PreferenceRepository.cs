using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class PrefereceRepository : RepositoryAsync<Preference>, IPreferenceRepository
    {
        private readonly ApplicationDbContext _db;
        public PrefereceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Preference preference)
        {
            var objFromDb = _db.Preference.FirstOrDefault(s => s.Id == preference.Id);
            if (objFromDb != null)
            {
                objFromDb.Language = preference.Language;
                objFromDb.Industry = preference.Industry;
            };
        }
    }
}
