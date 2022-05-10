using System.ComponentModel.DataAnnotations;


namespace CoureProject.Domain;

public class City
{
    [Key]
    public int Id { get; set; }
    public int WeatherID { get; set; }
    public string Name { get; set; }
}
