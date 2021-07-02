using System;

namespace Sddke.Shared.Domain
{
    /// <summary>
    /// The entity.
    /// </summary>
    public abstract class Entity : IEquatable<Entity>
    {

        /// <summary>
        /// The null entity.
        /// </summary>
        class NullEntity:Entity
        {

        }
        public static Entity Null = new NullEntity();

        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// The .ctor.
        /// </summary>
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="id">The id.</param>
        protected Entity(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The result.</returns>
        public bool Equals(Entity obj)
        {
            return Equals(obj as object);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The result.</returns>
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
                return false;
            var other = obj as Entity;
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetUnproxiedType(this) != GetUnproxiedType(other))
                return false;

            if (Id.Equals(default) || other.Id.Equals(default))
                return false;

            return Id.Equals(other.Id);
        }

        /// <summary>
        /// The op_ equality.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result.</returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        /// <summary>
        /// The op_ inequality.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result.</returns>
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>The result.</returns>
        public override int GetHashCode()=>(GetUnproxiedType(this).ToString() ,Id).GetHashCode();
      

        /// <summary>
        /// The get unproxied type.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The result.</returns>
        internal static Type GetUnproxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";
            const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
                return type.BaseType;

            return type;
        }
    }
}
