 using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class LanguageRepository : RepositoryAsync<Language>, ILanguageRepository
    {
        private readonly ApplicationDbContext _db;

        public LanguageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(Language language)
        {
            var objFromDb = _db.Languages.FirstOrDefault(s => s.Id == language.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = language.Name;
            };
        }

        
    }
}
