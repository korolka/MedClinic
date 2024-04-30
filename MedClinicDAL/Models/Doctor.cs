using System.ComponentModel.DataAnnotations.Schema;

namespace MedClinicDAL.Models
{
	public class Doctor : BaseModel
	{
		public string Name { get; set; }
		public string SurName { get; set; }
		public DateTime BirthDay { get; set; }
		public DateTime DayStartOfWork { get; set; }
		public decimal CostForOneVisit { get; set; }
		public Guid SpecializationId	 { get; set; }
		public Specialization Specialization { get; set; }
		public string LinkPhoto { get; set; }
		public string PassportId { get; set; }
		public List<Record>? Records { get; set; }
		public List<Slot> Slots { get; set; }
		public string MiddleName { get; set; }
		public Clinic Clinic { get; set; }
		public Guid ClinicId { get; set;}
	}
}