using CoureProject.Interfaces.Base;

namespace CoureProject.Domain.Base.Entities;

public abstract class Entity: IEntity, IEquatable<Entity>
{
    public int id { get; set; }

    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return id == other.id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Entity)obj);
    }
    public override int GetHashCode()
    {
        return id;
    }

    public static bool operator == (Entity? left, Entity? right) { return Equals(left, right); }
    public static bool operator != (Entity? left, Entity? right) { return !Equals(left, right); }
}
