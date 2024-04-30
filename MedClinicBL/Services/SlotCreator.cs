using MedClinicDAL.IRepository;
using MedClinicDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicBL.Services
{
	public class SlotCreator : ISlotCreator
	{

		public async Task<List<Slot>> GenerateSlots(Doctor doc, DateTime date, ISlotRepository repository)
		{

			List<Slot> slots = new List<Slot>();

			if (await DayIsOccupied(doc.ID,date,repository))
			{
				return slots;
			}
			slots.AddRange(GenerateSlotsForShift(doc, date, 8, 14, 20));
			slots.AddRange(GenerateSlotsForShift(doc, date, 14, 15, 60));
			slots.AddRange(GenerateSlotsForShift(doc, date, 15, 19, 20));
			return slots;
		}
		public List<Slot> GenerateSlotsForShift(Doctor doctor, DateTime date, int startTimeInt, int endTimeInt, int interval)
		{
			DateTime startSlotTime = date.AddHours(startTimeInt);
			DateTime endSlotTime = date.AddHours(startTimeInt).AddMinutes(interval);
			int slotsCount = GenerateSlotsCount(date.AddHours(startTimeInt), date.AddHours(endTimeInt), interval);
			List<Slot> slots = new List<Slot>();

			for (int i = 0; i < slotsCount; i++)
			{
				slots.Add(new Slot()
				{

					AppointmentIntervalMinutes = interval,
					DayOfWeek = date.DayOfWeek,
					DoctorId = doctor.ID,
					EndTime = endSlotTime,
					StartTime = startSlotTime,
					IsOccupied = false
				});

				startSlotTime = startSlotTime.AddMinutes(20);
				endSlotTime = endSlotTime.AddMinutes(20);
			}
			return slots;
		}

		public int GenerateSlotsCount(DateTime startTime, DateTime endTime, int interval)
		{
			int count = 0;
			while (startTime < endTime)
			{
				startTime = startTime.AddMinutes(interval);
				count++;
			}
			return count;
		}

		private async Task<bool> DayIsOccupied(Guid doctor, DateTime date, ISlotRepository repository)
		{
			var slots = await repository.GetAllByPredicate(s => s.StartTime.Date == date.Date && s.DoctorId == doctor);
			return slots.Any();

		}


	}
}
