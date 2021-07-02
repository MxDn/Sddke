using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sddke.Shared.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        class Null : ValueObject
        {

        }
        public static ValueObject NullValueObject = new Null();
        private static IEnumerable<PropertyInfo> properties = new List<PropertyInfo>();
        private static IEnumerable<FieldInfo> fields = new List<FieldInfo>();

        /// <summary>
        /// The op_ equality.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>The result.</returns>
        public static bool operator ==(ValueObject obj1, ValueObject obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// The op_ inequality.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>The result.</returns>
        public static bool operator !=(ValueObject obj1, ValueObject obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>The result.</returns>
        public bool Equals(ValueObject obj)
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
            if (obj == null || GetType() != obj.GetType()) return false;

            return GetProperties().All(p => PropertiesAreEqual(obj, p))
                && GetFields().All(f => FieldsAreEqual(obj, f));
        }

        /// <summary>
        /// The properties are equal.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="p">The p.</param>
        /// <returns>The result.</returns>
        private bool PropertiesAreEqual(object obj, PropertyInfo p)
        {
            return Equals(p.GetValue(this, null), p.GetValue(obj, null));
        }

        /// <summary>
        /// The fields are equal.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="f">The f.</param>
        /// <returns>The result.</returns>
        private bool FieldsAreEqual(object obj, FieldInfo f)
        {
            return Equals(f.GetValue(this), f.GetValue(obj));
        }

        /// <summary>
        /// The get properties.
        /// </summary>
        /// <returns>The result.</returns>
        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (properties.Any())
            {
                return properties;
            }
            properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            return properties;
        }

        /// <summary>
        /// The get fields.
        /// </summary>
        /// <returns>The result.</returns>
        private IEnumerable<FieldInfo> GetFields()
        {
            if (fields == null)
            {
                fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public).ToList();
            }

            return fields;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>The result.</returns>
        public override int GetHashCode() => (GetFields().ToArray(), GetProperties().ToArray()).GetHashCode();

    }
}
