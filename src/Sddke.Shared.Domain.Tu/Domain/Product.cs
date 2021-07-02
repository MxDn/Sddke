using System;
using Sddke.Shared.Domain;

namespace Sddke.Shared.Tu.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        public Product(Name name) : this(Guid.NewGuid(), name)
        {
        }

        public Product(Guid id, Name name = null) : base(id)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public Name Name { get; private set; }
        public BackLog BackLog { get; private set; }
        public BackLog CreateBacklog()
        {
            this.BackLog = new BackLog(this);
            return this.BackLog;
        }
    }
}
