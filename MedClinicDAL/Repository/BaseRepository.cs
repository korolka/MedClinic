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
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel, new()
	{
		Context db;
		DbSet<T> setDb;
		public BaseRepository(Context db)
		{
			this.db = db;
			setDb = this.db.Set<T>();
		}
		public async Task<bool> Add(T entity)
		{
			setDb.Add(entity);
			return await db.SaveChangesAsync() != 0;
		}

		public async Task<bool> DeleteById(Guid id)
		{
			T entity = new T() { ID = id };
			setDb.Entry(entity).State = EntityState.Deleted;
			return await db.SaveChangesAsync() != 0;
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await setDb.ToListAsync();
		}

		public async Task<T> GetById(Guid id)
		{
			T entity = await setDb.FirstOrDefaultAsync(t => t.ID == id);
			return entity;
		}

		public async Task<T> GetByPredicate(Expression<Func<T, bool>> predicate)
		{
			return await setDb.Where(predicate).FirstOrDefaultAsync();
		}

        public async Task<IEnumerable<T>> GetAllByPredicate(Expression<Func<T, bool>> predicate)
        {
			return await setDb.Where(predicate).ToListAsync();
        }

        public async Task<bool> Update(T entity)
		{
			setDb.Update(entity);
			return await db.SaveChangesAsync() !=0;
		}

		public async Task<bool> DeleteRange(List<T> entity)
		{
			setDb.RemoveRange(entity);
			return await db.SaveChangesAsync() !=0;
		}
	}
}
