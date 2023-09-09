using System.ComponentModel.DataAnnotations;

namespace CSMA.API.Web.ApiModels;

public class SalonServiceDTO : CreateSalonServiceDTO
{
  public int Id { get; set; }

  public SalonServiceDTO(string name, decimal price) 
          : base(name, price)
  {
      Name = name;
      Price = price;
  }
}


public class CreateSalonServiceDTO
{
  [Required]
  public string Name { get; set; }

  [Required]
  public decimal Price { get; set; }

  public TimeSpan Duration { get; set; }

  public string? Description { get; set; }

  public byte[]? DisplayImage { get; set; }

  public CreateSalonServiceDTO(string name, decimal price)
  {
    Name = name;
    Price = price;
  }
}
