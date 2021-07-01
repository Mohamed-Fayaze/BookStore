using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class RestaurantRepository : RepositoryAsync<Restaurant>, IRestaurantRepository
    {
        private readonly ApplicationDbContext _db;

        public RestaurantRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Restaurant restaurant)
        {

            var objFromDb = _db.Restaurants.FirstOrDefault(s => s.Id == restaurant.Id);
            if (objFromDb != null)
            {
                objFromDb.Amenities = restaurant.Amenities;
                objFromDb.Cuisines = restaurant.Cuisines;
                objFromDb.DietaryRestrictions = restaurant.DietaryRestrictions;
                objFromDb.Dishes = restaurant.Dishes;
                objFromDb.DoorDelivery = restaurant.DoorDelivery;
                objFromDb.Features = restaurant.Features;
                objFromDb.GoodFor = restaurant.GoodFor;
                objFromDb.Meals = restaurant.Meals;
                objFromDb.miniprice = restaurant.miniprice;
                objFromDb.OnlineBooking = restaurant.OnlineBooking;
                objFromDb.Paymentmode = restaurant.Paymentmode;
            };
        }
    }
}
