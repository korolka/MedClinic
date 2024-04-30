﻿using MedClinicDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicDAL.IRepository
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User> GetUserIncudeRole(Guid roleId);
	}
}
