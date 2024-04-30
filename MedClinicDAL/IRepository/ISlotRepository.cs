using MedClinicDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicDAL.IRepository
{
	public interface ISlotRepository:IBaseRepository<Slot>
	{
		Task<bool> AddRangeAsync(List<Slot> slot);
	}
}
