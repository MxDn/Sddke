// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;

using Sddke.Shared.Domain;

namespace Agility.Domain.Backlog
{
    /// <summary>
    /// The back log item.
    /// </summary>
    public class BackLogItem : Entity
    {
        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="backLog">The back log.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public BackLogItem(Guid id, BackLog backLog, Name name, Description description) : base(id)
        {
            Name = name;
            Description = description;
            Owner = backLog;
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

        /// <summary>
        /// Gets or Sets the owner.
        /// </summary>
        public BackLog Owner { get; private set; }
    }
}
