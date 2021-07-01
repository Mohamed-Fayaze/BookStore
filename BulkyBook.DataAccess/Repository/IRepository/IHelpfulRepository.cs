using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IHelpfulRepository : IRepository<Helpful>
    {
        //void Update(Helpful helpful);
    }
}
