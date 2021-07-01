using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class FitnessRepository : RepositoryAsync<Fitness>, IFitnessRepository
    {
        private readonly ApplicationDbContext _db;

        public FitnessRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Fitness fitness)
        {

            var objFromDb = _db.Fitness.FirstOrDefault(s => s.Id == fitness.Id);
            if (objFromDb != null)
            {
                objFromDb.FitnessType = fitness.FitnessType;
                objFromDb.Gender = fitness.Gender;
                objFromDb.minprice = fitness.minprice;
                objFromDb.Mode = fitness.Mode;
                objFromDb.OnlineBooking = fitness.OnlineBooking;
                objFromDb.Traineravailable = fitness.Traineravailable;
            };
        }
    }
}
