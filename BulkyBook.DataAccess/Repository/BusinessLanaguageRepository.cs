using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class BusinessLanguageRepository : RepositoryAsync<BusinessLanguage> , IBusinessLanguageRepository
    {
        private readonly ApplicationDbContext _db;
        public BusinessLanguageRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        //public void Update(BusinessLanguage businessLanguage)
        //{
        //    var objFromDb = _db.BusinessLanguage.FirstOrDefault(s => s.Id == businessLanguage.Id);
        //    if (objFromDb != null)
        //    {
        //        objFromDb.busines = businessLanguage.Name;
        //    };
        //}
    }
}
