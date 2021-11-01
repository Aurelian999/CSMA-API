using System;

namespace CSMA_API.Domain
{
    public class EmployeeWorkingHours
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string WeekDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// Overrides the standard schedule for an employee for a specific date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
