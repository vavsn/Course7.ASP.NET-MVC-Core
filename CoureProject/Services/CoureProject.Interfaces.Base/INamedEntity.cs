using System.ComponentModel.DataAnnotations;

namespace CoureProject.Interfaces.Base;

public interface INamedEntity : IEntity
{
    [Required]
    string Name { get; set; }
}