using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ContactRepository : RepositoryAsync<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _db;
        public ContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(Contact contact)
        {
            var objFromDb = _db.Contact.FirstOrDefault(s => s.Id == contact.Id);
            if (objFromDb != null)
            {
                objFromDb.SocialName = contact.SocialName;
                objFromDb.SocialURL = contact.SocialURL;
                objFromDb.Website = contact.Website;
                objFromDb.ContactNumber = contact.ContactNumber;
                objFromDb.ContactPersonName = contact.ContactPersonName;
                objFromDb.EmergencyContactNumber = contact.EmergencyContactNumber;
            }
        }
    }
}
