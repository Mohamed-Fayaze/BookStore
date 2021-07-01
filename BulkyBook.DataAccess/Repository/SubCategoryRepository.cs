using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class SubCategoryRepository : RepositoryAsync<SubCategory>, ISubCategoryRepository
    {

        private readonly ApplicationDbContext _db;

        public SubCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(SubCategory subcategory)
        {
            var objFromDb = _db.SubCategory.FirstOrDefault(s => s.SecondaryId == subcategory.SecondaryId);
            if (objFromDb != null)
            {
                if (subcategory.SubCategoryIcon != null)
                {
                    objFromDb.SubCategoryIcon = subcategory.SubCategoryIcon;
                }

                if (subcategory.SubCategoryImage != null)
                {
                    objFromDb.SubCategoryImage = subcategory.SubCategoryImage;
                }


                objFromDb.SecondaryName = subcategory.SecondaryName;
                objFromDb.CategoryId = subcategory.CategoryId;
                 

                _db.SaveChanges();
            }
        }
    }
}
