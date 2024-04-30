using MedClinicDAL.IRepository;
using MedClinicDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicBL.Services
{
	public interface ISlotCreator
	{
	Task<List<Slot>> GenerateSlots(Doctor doc, DateTime date, ISlotRepository repository);

		List<Slot> GenerateSlotsForShift(Doctor doctor, DateTime date, int startTimeInt, int endTimeInt, int interval);
		int GenerateSlotsCount(DateTime startTime, DateTime endTime, int interval);
	}
}
