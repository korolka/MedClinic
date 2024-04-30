using System.ComponentModel.DataAnnotations;

namespace MedClinic.Models
{
	public class DoctorChooseBindingModel
	{
		[Required]
		public Guid ChoosenDoctor { get; set; }

        [Required]
        [Display(Name = "Selected Days")]
        public List<DateTime> SelectedDays { get; set; }

        public DoctorChooseBindingModel()
        {
            SelectedDays = new List<DateTime>();
        }
    }
}
