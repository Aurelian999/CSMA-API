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
    }
}
