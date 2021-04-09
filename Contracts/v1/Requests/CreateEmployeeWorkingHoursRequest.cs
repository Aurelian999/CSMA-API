using System;

namespace CSMA_API.Controllers.v1.Requests
{
    public class CreateEmployeeWorkingHoursRequest
    {
        public int UserId { get; set; }
        public string WeekDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
