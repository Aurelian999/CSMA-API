using CSMA_API.Contracts;
using CSMA_API.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CSMA_API.Controllers.v1
{
    public class EmployeeWorkingHoursController: ControllerBase
    {
        private List<EmployeeWorkingHours> _workingHours;

        public EmployeeWorkingHoursController()
        {
            _workingHours = new List<EmployeeWorkingHours>();
            for (int i = 0; i < 7; i++)
            {
                _workingHours.Add(new EmployeeWorkingHours { Id = i, UserId = i, WeekDay = DateTime.Now.DayOfWeek.ToString(), StartTime = new TimeSpan(8,0,0), EndTime = new TimeSpan(16, 0, 0) });
            }
        }

        [HttpGet(ApiRoutes.EmployeeWorkingHours.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_workingHours);
        }
    }
}
