using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class FAQRepository : Repository<FAQ>,IFAQRepository
    {
        private readonly ApplicationDbContext _db;

        public FAQRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FAQ fAQ)
        {
            var objFromDb = _db.FAQs.FirstOrDefault(s => s.Id == fAQ.Id);
            if (objFromDb != null)
            {
                objFromDb.FAQQuestion = fAQ.FAQQuestion;
                objFromDb.FAQAnswer = fAQ.FAQAnswer;
                objFromDb.QuestionOn = fAQ.QuestionOn;
                objFromDb.AnswerOn = fAQ.AnswerOn;
               
            }
        }
        public IEnumerable<FAQ> Search(string search)
        {

            var sea = from x in _db.FAQs select x;
            if (!String.IsNullOrEmpty(search))
            {
                sea = sea.Where(x => x.FAQQuestion.Contains(search) || x.FAQAnswer.Contains(search));
            }
            return  sea.ToList();
        }
        public bool ValidateFAQHelpful(string userId, int faqid)
        {
            return _db.FAQHelpfuls.Where(x => x.UserId == userId && x.FAQId == faqid).Any();
        }
        public bool ValidateFAQReportAbuse(string userId, int faqid)
        {
            return _db.FAQReportAbuses.Where(x => x.UserId == userId && x.FAQId == faqid).Any();
        }
    }
}
