using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class UserPrivateRepository : RepositoryAsync<UserPrivate> , IUserPrivateRepository
    {
        private readonly ApplicationDbContext _db;
        public UserPrivateRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(UserPrivate userPrivate)
        {
            var objFromDb = _db.UserPrivate.FirstOrDefault(s => s.Id == userPrivate.Id);
            if (objFromDb != null)
            {
                objFromDb.About = userPrivate.About;
                objFromDb.Occupation = userPrivate.Occupation;
                objFromDb.SchoolName = userPrivate.SchoolName;
                objFromDb.CollegeName = userPrivate.CollegeName;
                objFromDb.CompanyName = userPrivate.CompanyName;
                objFromDb.Position = userPrivate.Position;
                objFromDb.Gender = userPrivate.Gender;
                objFromDb.DateOfBirth = userPrivate.DateOfBirth;
                objFromDb.MaritalStatus = userPrivate.MaritalStatus;
            };
        }
    }
}
