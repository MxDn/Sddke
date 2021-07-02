// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;

using Sddke.Shared.Domain;

namespace Agility.Domain.Backlog
{
    /// <summary>
    /// The product.
    /// </summary>
    public class Product : Entity, IAggregateRoot
    {
        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="name">The name.</param>
        public Product(Name name) : this(Guid.NewGuid(), name)
        {
        }

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public Product(Guid id, Name name) : base(id)
        {
            Name = name;
            CreateBacklog();
        }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets or Sets the back log.
        /// </summary>
        public BackLog BackLog { get; private set; }

        /// <summary>
        /// The create backlog.
        /// </summary>
        /// <returns>The result.</returns>
        private BackLog CreateBacklog()
        {
            BackLog = new BackLog(this);
            return BackLog;
        }

        public BackLogItem AddBacklogItem(Name name, Description description)
        {
            return BackLog.CreateBackLogItem(name, description);
        }
    }
}
