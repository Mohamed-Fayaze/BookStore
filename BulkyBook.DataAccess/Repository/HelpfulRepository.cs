﻿using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class HelpfulRepository : Repository<Helpful>,IHelpfulRepository
    {
        private readonly ApplicationDbContext _db;

        public HelpfulRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Update(Helpful helpful)
        //{
        //    var objFromDb = _db.Helpfuls.FirstOrDefault(s => s.HelpfulID == helpful.HelpfulID);
        //    if (objFromDb != null)
        //    {
        //        objFromDb.ReviewRatingId = helpful.ReviewRatingId;
               
        //    }
        //}
    }
}
