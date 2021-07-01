using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IProfessionalAssistanceRepository : IRepositoryAsync<ProfessionalAssistance>
    {
        void Update(ProfessionalAssistance professionalAssistance);
    }
}
