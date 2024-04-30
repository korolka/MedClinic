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
	public class SlotRepository : BaseRepository<Slot>, ISlotRepository
	{
		Context db;
		DbSet<Slot> dbSet;
		public SlotRepository(Context db) : base(db)
		{
			this.db = db;
			dbSet = db.Set<Slot>();
		}

		public async Task<bool> AddRangeAsync(List<Slot> slot)
		{
			await dbSet.AddRangeAsync(slot);
			return await db.SaveChangesAsync() != 0;
		}
	}
}
