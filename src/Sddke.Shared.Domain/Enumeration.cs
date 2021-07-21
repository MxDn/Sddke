using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sddke.Shared.Domain
{
    public abstract class Enumeration<TKey> : IEquatable<Enumeration<TKey>> where TKey : IComparable
    {
        public string Name { get; private set; }

        public TKey Id { get; private set; }

        protected Enumeration(TKey id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration<TKey> =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherValue = obj as Enumeration<TKey>;
            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration<TKey>)other).Id);

        public override int GetHashCode() => (Id, Name).GetHashCode();

        public bool Equals(Enumeration<TKey> other) => Equals(other);
    }
}
