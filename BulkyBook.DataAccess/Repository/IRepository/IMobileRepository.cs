﻿using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IMobileRepository : IRepositoryAsync<Mobile>
    {
        Task UpsertAsync(IEnumerable<Mobile> Mobiles, int AddressId);
    }
}
