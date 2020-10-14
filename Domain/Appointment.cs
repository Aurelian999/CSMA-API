﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMA_API.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public string Details { get; set; }
    }
}
