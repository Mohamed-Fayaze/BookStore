using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUserPrivateRepository :IRepositoryAsync<UserPrivate>
    {
        void Update(UserPrivate userPrivate);
    }
}
