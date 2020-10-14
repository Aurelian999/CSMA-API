using CSMA_API.Contracts;
using CSMA_API.Controllers.v1.Requests;
using CSMA_API.Controllers.v1.Responses;
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

        [HttpGet(ApiRoutes.EmployeeWorkingHours.Get)]
        public IActionResult Get(int employeeId)
        {
            // TODO

            return Ok(_workingHours[employeeId]);
        }

        [HttpPost(ApiRoutes.EmployeeWorkingHours.Create)]
        public IActionResult Create([FromBody] CreateEmployeeWorkingHoursRequest request)
        {
            var workingHours = new EmployeeWorkingHours
            {
                Id = 9,
                UserId = request.UserId,
                WeekDay = request.WeekDay,
                StartTime = request.StartTime,
                EndTime = request.StartTime
            };

            _workingHours.Add(workingHours);


            var resp = new EmployeeWorkingHoursResponse
            {
                UserId = 1,
                StartTime = TimeSpan.FromSeconds(4800),
                EndTime = TimeSpan.FromSeconds(9800),
            };
            return Created("", resp);
        }
    }
}
