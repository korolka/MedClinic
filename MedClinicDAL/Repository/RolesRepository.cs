using MedClinicDAL.IRepository;
using MedClinicDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicDAL.Repository
{
	public class RolesRepository : BaseRepository<Roles>, IRolesRepository
	{
		Context db;
		DbSet<Roles> dbSet;
		public RolesRepository(Context db) : base(db)
		{
			this.db = db;
			dbSet= db.Set<Roles>();
		}

		public async Task<Roles> GetByRole(string roleName)
		{
			Roles role = await dbSet.FirstOrDefaultAsync(r=>r.Role == roleName);
			return role;
		}
	}
}
