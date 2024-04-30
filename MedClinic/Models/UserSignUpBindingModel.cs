using System.ComponentModel.DataAnnotations;

namespace MedClinic.Models
{
    public class UserSignUpBindingModel
    {
		[Required]
		public string Name { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
		public string SurName { get; set; }
		[Required]
		[UIHint("EmailAddress")]
		public string Email { get; set; }
		[Required]
		[UIHint("Password")]
		[MinLength(6)]
		public string Password { get; set; }
		[Required]
		[UIHint("Password")]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
		[Required]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }


    }
}
