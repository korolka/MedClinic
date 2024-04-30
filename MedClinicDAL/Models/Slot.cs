using System.ComponentModel.DataAnnotations.Schema;

namespace MedClinicDAL.Models
{
    public class Slot : BaseModel
    {
        public Doctor Doctor { get; set; }
		public Guid DoctorId { get; set; }

		public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AppointmentIntervalMinutes { get; set; }
        public bool IsOccupied { get; set; } // Флаг занятости
        public Record Record { get; set; }

    }
}