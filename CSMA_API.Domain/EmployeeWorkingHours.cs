using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMA_API.Domain
{
    public class EmployeeWorkingHours
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        /// <summary>
        /// Overrides the standard schedule for an employee for a specific date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
