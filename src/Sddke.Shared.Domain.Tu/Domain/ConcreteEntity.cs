using System;
using Sddke.Shared.Domain;

namespace Sddke.Shared.Tu.Domain
{
    /// <summary>
    /// The compagny.
    /// </summary>
    public class ConcreteEntity : Entity
    {
        class NullConcreteEntity : ConcreteEntity
        { }
        static NullConcreteEntity Null = new NullConcreteEntity();
        /// <summary>
        /// The .ctor.
        /// </summary>
        private ConcreteEntity() : base()
        {
        }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public ConcreteEntity(Guid id, Name name, Description description) : base(id)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public ConcreteEntity(Name name, Description description) : this(Guid.NewGuid(), name, description)
        {
        }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets or Sets the description.
        /// </summary>
        public Description Description { get; private set; }
        public ConcreteEntity ConcreteBehaviour()
        {
            return Null;
        }

    }
}
