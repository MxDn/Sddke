using Sddke.Shared.Domain;

namespace Sddke.Shared.Tu.Domain
{
     
        public class Name : ValueObject
        {
            public string Value { get; private set; }

            public Name(string value) => this.Value = value.NotNullOrWhiteSpace();

            public static implicit operator Name(string value)=>new Name(value);

            public static implicit operator string(Name name) => name.Value;
    }
}
