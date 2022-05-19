using CoureProject.Interfaces.Base;

namespace CoureProject.Domain.Base.Entities;

public abstract class NamedEntity : Entity, INamedEntity
{
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}