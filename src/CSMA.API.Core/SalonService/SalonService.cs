using System.Diagnostics;
using Ardalis.GuardClauses;
using CSMA.API.SharedKernel;
using CSMA.API.SharedKernel.Interfaces;

namespace CSMA.API.Core.SalonServiceAggregate;
public  class SalonService : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  public decimal Price { get; private set; }

  public TimeSpan Duration { get; set; }

  public string Description { get; set; } = string.Empty;

  public byte[]? DisplayImage { get; set; }

  public SalonService(string name, decimal price)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    Price = Guard.Against.Negative(price, nameof(price));
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void UpdatePrice(decimal newPrice)
  {
    Price = Guard.Against.Negative(newPrice, nameof(newPrice));
  }
}
