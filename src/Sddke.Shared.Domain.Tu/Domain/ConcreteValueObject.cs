using Sddke.Shared.Domain;

namespace Sddke.Shared.Tu.Domain
{
    /// <summary>
    /// The person.
    /// </summary>
    public class ConcreteValueObject : ValueObject
    {
        /// <summary>
        /// Gets or Sets the first name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets the last name.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="name">The last name.</param>
        /// <param name="description">The first name.</param>
        public ConcreteValueObject(string name, string description)
        {
            this.Name = description.NotNullOrWhiteSpace();
            this.Description = name.NotNullOrWhiteSpace();
        }
    }
}
