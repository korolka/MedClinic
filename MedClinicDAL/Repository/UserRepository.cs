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
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		Context db;
		DbSet<User> dbSet;
		public UserRepository(Context db) : base(db)
		{
			this.db = db;
			 dbSet = db.Set<User>();
		}

		public async Task<User> GetUserIncudeRole(Guid roleId)
		{
			User user = await dbSet.Include(r=>r.Role).FirstOrDefaultAsync(r=>r.Role.ID == roleId);
			return user;
		}
	}
}
