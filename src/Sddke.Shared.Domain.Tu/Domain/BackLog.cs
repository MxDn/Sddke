using System;
using System.Collections.Generic;
using Sddke.Shared.Domain;

namespace Sddke.Shared.Tu.Domain
{
    public class BackLog : Entity
    {
        private ICollection<BackLogItem> backLogItems = new List<BackLogItem>();
        public BackLog() : base(Guid.NewGuid())
        {
        }

        public BackLog(Product product) : this()
        { this.Owner = product; }

        public Product Owner { get; }

        public BackLogItem CreateBackLogItem(Name name, Description description)
        {
            BackLogItem backLogItem = new BackLogItem(this, name, description);
            this.backLogItems.Add(backLogItem);
            return backLogItem;
        }
    }
}
