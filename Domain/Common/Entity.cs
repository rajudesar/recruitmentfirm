using System.Collections.Generic;
using System.Linq;

namespace Domain.Common
{
    public abstract class Entity<T> : IEntity where T: struct 
    {
        private readonly ICollection<IDomainEvent> events;
        protected Entity() => this.events = new List<IDomainEvent>();
        public T Id { get; private set; } = default;

        public IReadOnlyCollection<IDomainEvent> Events => this.events.ToList().AsReadOnly();

        public override bool Equals(object obj)
        {
            if (!(obj is Entity<T> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            if (this.Id.Equals(default) || other.Id.Equals(default))
                return false;

            return this.Id.Equals(other.Id);
        }

        public static bool operator == (Entity<T>? first, Entity<T>? second)
        {
            if (first is null && second is null)
                return true;

            if (first is null || second is null)
                return false;
            return first.Equals(second);
        }

        public static bool operator !=(Entity<T>? first, Entity<T>? second) => !(first == second);

        public override int GetHashCode() => (this.GetType().ToString() + this.Id).GetHashCode();

        public void ClearEvents()
        {
            this.events.Clear();
        }
    }
}
