namespace CSMA_API.Application.Models
{
    public  class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public int LocationId { get; set; }
        public string Details { get; set; }
        public bool NoShow { get; set; }
    }
}
