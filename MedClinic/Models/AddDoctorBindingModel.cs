using MedClinicDAL.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MedClinic.Models
{
	public class AddDoctorBindingModel
	{
		[Required]
		public string Name { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
		public string SurName { get; set; }
		[Required]
		[DisplayName("Birthday:")]
		[DataType(DataType.Date)]
		public DateTime BirthDay { get; set; }
		[Required]
		[DisplayName("Day start of work:")]
		[DataType(DataType.Date)]
		public DateTime DayStartOfWork { get; set; }
		[Required]
		[DataType(DataType.Currency)]
		public decimal CostForOneVisit { get; set; }
		[Required]
		[DataType(DataType.ImageUrl)]
		public string LinkPhoto { get; set; }
		[Required]
		public Guid Specialization { get; set; }
        [Required]
        public Guid Clinic { get; set; }
        [Required]
		[DataType(DataType.Password)]
		public string PassportId { get; set; }
        [Required]
        [Display(Name = "Selected Days")]
        public List<DateTime> SelectedDays { get; set; }

        public AddDoctorBindingModel()
        {
            SelectedDays = new List<DateTime>();
        }

    }
}
