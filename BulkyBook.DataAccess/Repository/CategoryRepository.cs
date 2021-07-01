using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : RepositoryAsync<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(Category primaryCategory)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.CategoryId == primaryCategory.CategoryId);
            if (objFromDb != null)
            {
                if (primaryCategory.CategoryIcon != null)
                {
                    objFromDb.CategoryIcon = primaryCategory.CategoryIcon;
                }

                if (primaryCategory.CategoryImage != null)
                {
                    objFromDb.CategoryImage = primaryCategory.CategoryImage;
                }


                objFromDb.CategoryName = primaryCategory.CategoryName;

                _db.SaveChanges();
            }

        }

    }
}
