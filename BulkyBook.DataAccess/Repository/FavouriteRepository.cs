using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class FavouriteRepository : RepositoryAsync<Favourite> , IFavouriteRepository
    {
        private readonly ApplicationDbContext _db;
        public FavouriteRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

    }
}
