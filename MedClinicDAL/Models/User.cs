using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicDAL.Models
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Record>? Records { get; set; }
		public Guid RoleId { get; set; }

		public Roles Role { get; set; }
    }
}
