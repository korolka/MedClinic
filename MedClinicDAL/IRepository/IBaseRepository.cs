using MedClinicDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicDAL.IRepository
{
	public interface IBaseRepository<T> where T : BaseModel, new()
	{
		Task<IEnumerable<T>> GetAll();

		Task<T> GetById(Guid id);
		Task<bool> DeleteById(Guid id);
		Task<bool> Update(T entity);
		Task<bool> Add(T entity);
		Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllByPredicate(Expression<Func<T, bool>> predicate);

		Task<bool> DeleteRange(List<T> doctors);
    }
}
