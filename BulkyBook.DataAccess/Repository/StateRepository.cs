using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class StateRepository : RepositoryAsync<State>, IStateRepository
    {
        private readonly ApplicationDbContext _db;

        public StateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(State state)
        {

            var objFromDb = _db.State.FirstOrDefault(s => s.Id == state.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = state.Name;
            };
        }
    }
}
