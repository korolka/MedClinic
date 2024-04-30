using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MedClinic.Models
{
	public class SearchDocBindingModel
	{
		[DisplayName("Name or Surname")]
		[Required]
		public string SurNameOrSpecialization { get; set; }
	}
}
