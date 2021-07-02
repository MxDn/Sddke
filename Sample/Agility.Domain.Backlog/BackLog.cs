// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System.Collections.Generic;
using System.Collections.ObjectModel;

using Sddke.Shared.Domain;

namespace Agility.Domain.Backlog
{
    /// <summary>
    /// The back log.
    /// </summary>
    public class BackLog : Entity
    {
        private readonly ICollection<BackLogItem> items = new List<BackLogItem>();

        /// <summary>
        /// Gets the back log items.
        /// </summary>
        public IReadOnlyCollection<BackLogItem> BackLogItems => new ReadOnlyCollection<BackLogItem>(items as List<BackLogItem>);

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="product">The product.</param>
        internal BackLog(Product product) : base(product.Id)
        {
            Owner = product;
        }

        /// <summary>
        /// Gets the owner.
        /// </summary>
        public Product Owner { get; }

        /// <summary>
        /// The create back log item.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <returns>The result.</returns>
        internal BackLogItem CreateBackLogItem(Name name, Description description)
        {
            var backLogItem = new BackLogItem(this, name, description);
            items.Add(backLogItem);
            return backLogItem;
        }
    }
}
