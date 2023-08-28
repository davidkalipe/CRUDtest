using System.ComponentModel.DataAnnotations;

namespace CRUDtest.Models;

public class Car
{
    [Key]
    public int CarId { get; set; }
    public string Name { get; set; }
    public string Mark { get; set; }
    public string Color { get; set; }
}