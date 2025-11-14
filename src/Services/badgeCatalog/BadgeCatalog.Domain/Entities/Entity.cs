namespace BadgeCatalog.Domain.Entities;

public abstract class Entity : IEquatable<Entity>
{
    #region Properties
    public Guid Id { get; private set; }
    #endregion
    #region Constructors
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    #endregion
    #region Methods
    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }
    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    #endregion
}