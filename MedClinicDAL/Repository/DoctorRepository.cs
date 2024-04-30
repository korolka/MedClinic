using MedClinicDAL.IRepository;
using MedClinicDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicDAL.Repository
{
	public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
	{
		Context db;
		DbSet<Doctor> setDb;
		public DoctorRepository(Context db) : base(db)
		{
			this.db = db;
			setDb= db.Set<Doctor>();
		}
		public async Task<IEnumerable<Doctor>> GetAllByPredicate(Expression<Func<Doctor, bool>> predicate)
		{
			return await setDb.Where(predicate).Include(d=>d.Specialization).Include(d=>d.Slots).ToListAsync();
		}
		public async Task<IEnumerable<Doctor>> GetAll()
		{
			return await setDb.Include(d=>d.Slots).ToListAsync();
		}
	}
}
