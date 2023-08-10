using Ardalis.GuardClauses;
using CSMA.API.SharedKernel;
using CSMA.API.SharedKernel.Interfaces;

namespace CSMA.API.Core.AppointmentAggregate;
public class Appointment : EntityBase, IAggregateRoot
{
  // TODO link to Service
  // TODO link to Client
  // TODO link to Employee who is providing the service
  public DateTime Date { get; set; }

  //public Location Location { get; set; } // TODO

  public bool NoShow { get; private set; }

  public string Details { get; set; } = string.Empty;

  public Appointment(DateTime date)
  {
    // TODO service/client/employee
    Date = Guard.Against.AgainstExpression(d => d < DateTime.Now, date, nameof(date));
  }
}
