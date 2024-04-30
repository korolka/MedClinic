using System.ComponentModel.DataAnnotations.Schema;

namespace MedClinicDAL.Models
{
    public class Record : BaseModel
    {
        public User User  { get; set; }
        public Doctor Doctor { get; set; }
		public Guid SlotId { get; set; }

		public Slot Slot { get; set; }


    }
}