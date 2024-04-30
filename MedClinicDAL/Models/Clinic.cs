﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedClinicDAL.Models
{
    public class Clinic: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}
