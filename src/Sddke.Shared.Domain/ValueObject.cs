using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sddke.Shared.Domain
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        private class Null : ValueObject
        {
        }
        public static ValueObject NullValueObject = new Null();
        private static List<PropertyInfo> properties;
        private static List<FieldInfo> fields;

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

        public static bool operator !=(ValueObject obj1, ValueObject obj2) => !(obj1 == obj2);

        public bool Equals(ValueObject obj) => Equals(obj as object);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return GetProperties().All(p => PropertiesAreEqual(obj, p))
                && GetFields().All(f => FieldsAreEqual(obj, f));
        }

        private bool PropertiesAreEqual(object obj, PropertyInfo p) => Equals(p.GetValue(this, null), p.GetValue(obj, null));

        private bool FieldsAreEqual(object obj, FieldInfo f) => Equals(f.GetValue(this), f.GetValue(obj));

        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (properties == null)
            {
                properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            }

            return properties;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            if (fields == null)
            {
                fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public).ToList();
            }

            return fields;
        }

        public override int GetHashCode() => (GetFields().ToArray(), GetProperties().ToArray()).GetHashCode();
    }
}
