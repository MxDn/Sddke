using System;
using Sddke.Shared.Domain;

namespace Sddke.Shared.Tu.Domain
{
    public class BackLogItem : Entity
    {
        public BackLogItem(Guid id, BackLog backLog, Name name, Description description) : base(id)
        {
            this.Name = name;
            this.Description = description;
            this.Owner = backLog;
        }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public BackLogItem(BackLog backLog, Name name, Description description) : this(Guid.NewGuid(), backLog, name, description)
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

        public BackLog Owner { get; private set; }

    }
}
