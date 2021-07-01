using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IRestaurantRepository : IRepositoryAsync<Restaurant>
    {
        void Update(Restaurant restaurant);
    }
}
