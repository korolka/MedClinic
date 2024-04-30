using MedClinicDAL.IRepository;
using MedClinicDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicDAL.Repository
{
    public class ClinicRepository : BaseRepository<Clinic>,IClinicRepository
    {
        public ClinicRepository(Context db) : base(db)
        {
        }

    }
}
