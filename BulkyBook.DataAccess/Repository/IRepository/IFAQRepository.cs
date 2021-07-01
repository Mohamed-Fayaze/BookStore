using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IFAQRepository : IRepository<FAQ>
    {
        void Update(FAQ fAQ);
        IEnumerable<FAQ> Search(string search);

        bool ValidateFAQHelpful(string userId, int faqid);
        bool ValidateFAQReportAbuse(string userId, int faqid);
    }
}
