using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    class EmailRepository : RepositoryAsync<Email>, IEmailRepository
    {
        private readonly ApplicationDbContext _db;
        public EmailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpsertAsync(IEnumerable<Email> Emails, int AddressId)
        {
            var objFromDb = from a in _db.EmailTables where a.AddressId == AddressId select a;
            if (objFromDb != null)
            {
                _db.EmailTables.RemoveRange(objFromDb);
            }
            foreach (var item in Emails)
            {
                item.AddressId = AddressId;
            }
            await _db.AddRangeAsync(Emails);
        }
    }
}
