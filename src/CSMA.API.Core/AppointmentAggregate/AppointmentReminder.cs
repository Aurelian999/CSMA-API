using CSMA.API.SharedKernel;

namespace CSMA.API.Core.AppointmentAggregate;
public class AppointmentReminder : EntityBase
{
  // TODO link to appointment

  public TimeSpan TimeBefore { get; set; }

  public ReminderType ReminderType { get; set; }

  public bool IsSent { get; set; }
}
