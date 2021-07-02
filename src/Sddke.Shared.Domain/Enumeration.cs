using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sddke.Shared.Domain
{

    /// <summary>
    /// The enumeration.
    /// </summary>
    public abstract class Enumeration : IComparable
    {

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The result.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>The result.</returns>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The result.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            var otherValue = obj as Entity;
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        /// <summary>
        /// The compare to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>The result.</returns>
        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>The result.</returns> 
        public override int GetHashCode() => (this.Id, this.Name).GetHashCode();
         
    }
}
