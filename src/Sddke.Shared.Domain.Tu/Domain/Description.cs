using Sddke.Shared.Domain;

namespace Sddke.Shared.Tu.Domain
{
    public class Description : ValueObject
    {
        public string Value { get; private set; }

        public Description(string value) => this.Value = value.NotNullOrWhiteSpace();

        public static implicit operator Description(string value) => new Description(value);

        public static implicit operator string(Description description) => description.Value;
    }
}
