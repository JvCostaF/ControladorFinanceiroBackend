using System;

namespace ControladorFinanceiro.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTime CreateAt { get; protected set; }
    public DateTime UpdateAt { get; protected set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreateAt = DateTime.UtcNow;
    }

    public void MarkAsUpdated()
    {
        UpdateAt = DateTime.UtcNow;
    }

    public override bool Equals(object obj)
    {
        if (obj is not BaseEntity other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (Id == Guid.Empty || other.Id == Guid.Empty) return false;
        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}
